using ICT13580049FinalA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICT13580049FinalA
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductNewPage : ContentPage
	{
        Product product;
		public ProductNewPage (Product product = null)
		{
			InitializeComponent ();

            this.product = product;

            titleLabel.Text = product == null ? "เพิ่มข้อมูลใหม่" : "แก้ไขข้อมูล";
           

            saveButton.Clicked += SaveButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;

            departmentPicker.Items.Add("ไอที");
            departmentPicker.Items.Add("บัญชี");
            departmentPicker.Items.Add("การตลาด");
            departmentPicker.Items.Add("ผลิต");


            genderPicker.Items.Add("ชาย");
            genderPicker.Items.Add("หญิง");

            statusPicker.Items.Add("โสด");
            statusPicker.Items.Add("แต่งงานแล้ว");

            
    

            if (product != null)
            {
                nameEntry.Text = product.Name;
                lastnameEntry.Text = product.Lastname;
                ageEntry.Text = product.Age.ToString();
                genderPicker.SelectedItem = product.Gender;
                departmentPicker.SelectedItem = product.Department;
                phoneEntry.Text = product.Phone.ToString();
                emailEntry.Text = product.Email.ToString();
                addressEditor.Text = product.Address.ToString();
                statusPicker.SelectedItem = product.Status;
                chlidLabel.Text = product.Children.ToString();
                salaryEntry.Text = product.Saraly;
                
            }

        }


        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");

            if (isOk)
            {
                if (product == null)
                {
                    var product = new Product();
                    product.Name = nameEntry.Text;
                    product.Lastname = lastnameEntry.Text;
                    product.Age = int.Parse(ageEntry.Text);
                    genderPicker.SelectedItem = product.Gender;
                    departmentPicker.SelectedItem = product.Department;
                    product.Phone = int.Parse(phoneEntry.Text);
                    product.Email = emailEntry.Text;
                    product.Address = addressEditor.Text;
                    statusPicker.SelectedItem = product.Status;
                    product.Saraly = salaryEntry.Text;
                   


                    var id = App.DbHelper.AddProduct(product);
                  
                    await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ" + id, "ตกลง");

                }

                else
                {
                    product.Name = nameEntry.Text;
                    product.Lastname = lastnameEntry.Text;
                    product.Age = int.Parse(ageEntry.Text);
                    product.Gender = genderPicker.SelectedItem.ToString();
                    product.Department = departmentPicker.SelectedItem.ToString();
                    product.Phone = int.Parse(phoneEntry.Text);
                    product.Email = emailEntry.Text;
                    product.Status = statusPicker.SelectedItem.ToString();
                    //product.Children = chlidLabel.ToString();
                    product.Address = addressEditor.Text;
                    product.Saraly = salaryEntry.Text;


                    var id = App.DbHelper.UpdateProduct(product);
                    await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลสินค้า" + id, "ตกลง");
                }
                await Navigation.PopModalAsync();
            }
        }


    
        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
            
        }


        private void MyStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            chlidLabel.Text = value.ToString();


        }

    }
}