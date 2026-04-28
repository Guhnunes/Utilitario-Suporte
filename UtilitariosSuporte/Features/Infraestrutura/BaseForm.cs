using System.Drawing;
using System.Windows.Forms;

namespace UtilitariosSuporte.Features.Infraestrutura
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            try
            {
                using (var ms = new System.IO.MemoryStream(Properties.Resources.SBRIcon))
                {
                    this.Icon = new System.Drawing.Icon(ms);
                }
            }
            catch
            {
                // Fallback caso o ícone não seja encontrado
            }
        }
    }
}