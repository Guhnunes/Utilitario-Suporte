using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitariosSuporte.Features.Compartilhamento.View;
using UtilitariosSuporte.Features.Infraestrutura;

namespace UtilitariosSuporte.Features.Compartilhamento.Presenter
{
    public class CompartilhamentoPresenter : BasePresenter<ICompartilhamentoView>
    {

        public CompartilhamentoPresenter() : base(null)
        {
        }

        public override void SetView(ICompartilhamentoView view)
        {
            base.SetView(view);
            View.ConfirmarClicked += OnConfirmarClicked;
        }

        private async void OnConfirmarClicked(object sender, EventArgs e)
        {
            try
            {
                ((Control)sender).Enabled = false;

                await Task.Run(() => ExecutarComandosDeRede());

                ControleDeMensagens.Informar("Configurações aplicadas! Reinicie o PC para garantir que o SMB1 foi ativado.");
            }
            catch (Exception ex)
            {
                ControleDeMensagens.Avisar($"Erro: {ex.Message}");
            }
            finally
            {
                ((Control)sender).Enabled = true;
            }
        }
        private void ExecutarComandosDeRede()
        {
            ExecutarPrompt("netsh advfirewall firewall set rule group=\"Compartilhamento de Arquivo e Impressora\" new enable=Yes");
            ExecutarPrompt("netsh advfirewall firewall set rule group=\"Descoberta de Rede\" new enable=Yes");

            ExecutarPrompt("dism /online /enable-feature /featurename:SMB1Protocol /norestart");
            ExecutarPrompt("dism /online /enable-feature /featurename:SMB1Protocol-Client /norestart");
            ExecutarPrompt("dism /online /enable-feature /featurename:SMB1Protocol-Server /norestart");

            ExecutarPrompt("sc.exe config lanmanworkstation depend= bowser/mrxsmb10/mrxsmb20/nsi");
            ExecutarPrompt("sc.exe config lanmanserver depend= samss/srv2");

            ExecutarPrompt("powershell.exe -ExecutionPolicy Bypass -Command \"Set-SmbServerConfiguration -EnableSMB2Protocol $true -Force\"");

            ExecutarPrompt("powershell.exe -ExecutionPolicy Bypass -Command \"Set-SmbClientConfiguration -RequireSecuritySignature $false -Force\"");

            ExecutarPrompt("reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\LanmanWorkstation\" /v AllowInsecureGuestAuth /t REG_DWORD /d 1 /f");

            ExecutarPrompt("reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Lsa\" /v everyoneincludesanonymous /t REG_DWORD /d 1 /f");
            ExecutarPrompt("reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters\" /v restrictanonymous /t REG_DWORD /d 0 /f");

            ExecutarPrompt("gpupdate /force");
        }
        private void ExecutarPrompt(string comando)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/c " + comando)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                Verb = "runas"
            };

            using (Process p = Process.Start(psi))
            {
                p?.WaitForExit();
            }
        }
    }
}