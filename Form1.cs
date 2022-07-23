using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace Instagram_Bot__Selenium_
{
    public partial class Form1 : Form
    {


        
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(guna2TextBox3.Text == "" || guna2TextBox1.Text == "" || guna2TextBox2.Text == "")
            {

            }
            else
            {
                Thread th = new Thread(mainSystem);
                th.Start();
            } 
        }

        private void mainSystem()
        {
            try
            {
                ChromeDriver drv;

                ChromeOptions option = new ChromeOptions();
                option.AddExcludedArgument("enable-automation");

                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;

                drv = new ChromeDriver(service, option);
                drv.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");

                Thread.Sleep(2500);

                var username = drv.FindElement(By.XPath("//input[@name='username']"));
                username.SendKeys(guna2TextBox1.Text);
                var password = drv.FindElement(By.XPath("//input[@name='password']"));
                password.SendKeys(guna2TextBox2.Text);
                var button = drv.FindElement(By.XPath("//button[@type='submit']"));
                button.Click();

                Thread.Sleep(4000);

                drv.Navigate().GoToUrl(guna2TextBox3.Text);

                Thread.Sleep(4000);

                var lastreel = drv.FindElement(By.XPath("//body//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div[1]//div[1]//a[1]//div[1]//div[2]"));
                lastreel.Click();

                Thread.Sleep(4000);

                int time = 5000;
                int sayac = 0;
                int time2 = 0;
                int commentCount = 0;

                for (; ; )
                {

                    bool staleElement = true;

                    while (staleElement)
                    {
                        try
                        {
                            drv.FindElement(By.XPath("(//textarea[@placeholder='Yorum ekle...'])[1]")).SendKeys("#keşfet#kesfet#reelsinstagram#kesfetteyiz#keşfetteyiz#fyp#fypage#fypシ#keşfet#kesfet#reelsinstagram#kesfetteyiz#keşfetteyiz#fyp#fypage#fypシ#keşfet#kesfet#reelsinstagram#kesfetteyiz#keşfetteyiz#fyp#fypage#fypシ");
                            commentCount++;
                            guna2HtmlLabel4.Text = "Yapılan Yorum Sayısı: " + commentCount;

                            Thread.Sleep(100);

                            var share = drv.FindElement(By.XPath("(//div[@class='_aacl _aaco _aacw _aad0 _aad6 _aade'])[1]"));
                            share.Click();

                            Thread.Sleep(time);

                            time += 1000;

                            sayac += 1;

                            if (sayac == 7)
                            {
                                while (time2 <= 299)
                                {
                                    Thread.Sleep(1000);
                                    time2++;
                                    guna2HtmlLabel2.Text = "Süre: " + time2.ToString();
                                }

                                sayac = 0;
                                time = 0;
                                time2 = 0;
                            }

                            staleElement = false;
                        }
                        catch (StaleElementReferenceException)
                        {
                            staleElement = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                listBox1.Items.Add(e.ToString());
            }  
        }
    }
}
