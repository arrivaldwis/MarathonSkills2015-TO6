using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarathonSkills2015_TO6.Class
{
    public class validation
    {
        public String emailPassVal(TextBox txtEmail, TextBox txtPassword, TextBox txtPasswordAgain)
        {
            String pesan = "sukses";
            try
            {
                string email = new MailAddress(txtEmail.Text).Address;
                if (email.IndexOfAny(".".ToCharArray()) != -1)
                {
                    if (!email.Contains("..") || email.Contains(".@") || email.Contains("@.") || email.Contains("._."))
                    {
                        if (!email.EndsWith("."))
                        {
                            if (txtPassword.Text.Length >= 5 && txtPassword.Text.Any(x => char.IsDigit(x)) && txtPassword.Text.Any(x => char.IsUpper(x) && txtPassword.Text.IndexOfAny("!@#$%^".ToCharArray()) != -1))
                            {
                                if (txtPassword.Text == txtPasswordAgain.Text)
                                {
                                    return pesan;
                                }
                                else
                                {
                                    pesan = "Password not match!";
                                    return pesan;
                                }
                            }
                            else
                            {
                                pesan = "Password not meet requirement!";
                                return pesan;
                            }
                        }
                        else
                        {
                            pesan = "Email not valid!";
                            return pesan;
                        }
                    }
                    else
                    {
                        pesan = "Email not valid!";
                        return pesan;
                    }
                }
                else
                {
                    pesan = "Email not valid!";
                    return pesan;
                }
            }
            catch (Exception ex)
            {
                pesan = ex.Message;
                return pesan;
            }
        }
    }
}
