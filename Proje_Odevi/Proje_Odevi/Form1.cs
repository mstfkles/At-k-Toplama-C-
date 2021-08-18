using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Proje_Odevi
{
    public partial class formAtıkToplama : Form
    {
        public formAtıkToplama()
        {
            InitializeComponent();
        }
        private void PasifYap()
        {
            pnlCam.Enabled = false;
            pnlKagit.Enabled = false;
            pnlMetal.Enabled = false;
            pnlOrganikAtik.Enabled = false;
        }
        private void AktifYap()
        {
            pnlCam.Enabled = true;
            pnlKagit.Enabled = true;
            pnlMetal.Enabled = true;
            pnlOrganikAtik.Enabled = true;
        }

        public interface IAtik
        {
            int Hacim { get; }
            System.Drawing.Image Image { get; }
        }
        public interface IAtikKutusu : IDolabilen
        {  
            
            /// <summary>     /// Atık kutusu boşaltıldığında oyun puanına kaç puan ekleneceğini döndürür.  
               int BosaltmaPuani { get; } 

              /// <summary>     /// Atık kutusunda gönderilen atığı alacak kadar boş yer varsa atığı kutuya ekler.    
              /// /// </summary>     /// <param name="atik">Eklenecek Atık</param>     
              /// /// <returns>Atığın kutuya eklenip eklenmediğini döndürür.</returns>   
              bool Ekle(Atik atik);       
              /// /// <summary>     /// Atık kutusunun doluluk oranı %75'in üstündeyse atık kutusunu boşaltır.     
              /// /// </summary>     /// <returns>Atık kutusunun boşaltılıp boşaltılmadığını döndürür.</returns>   
              bool Bosalt(); 
              /// } 
        }     
        public interface IDolabilen
        {
            int Kapasite { get; set; }
            int DoluHacim { get; }
            int DolulukOrani { get; }
        }        
        private void formAtıkToplama_Load(object sender, EventArgs e)
        {
            PasifYap();      
        }
        private void zaman_Tick(object sender, EventArgs e)
        {
            int geriSayim = Convert.ToInt32(txtSure.Text);
            geriSayim--; 
            txtSure.Text = geriSayim.ToString();
            if (geriSayim == 0)
            {
                zaman.Enabled = false;
                PasifYap();
            }
        }
        private void btnYeniOyun_Click(object sender, EventArgs e)
        {
            zaman.Enabled = true;
            zaman.Interval = 100;
            AktifYap();
          
        }
    }
}
