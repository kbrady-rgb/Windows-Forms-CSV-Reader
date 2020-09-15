using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

/***************************************************************
* Name        : CSV Reader
* Author      : Kabrina Brady
* Created     : 10/12/2019
* Course      : C/S 169 - C#
* Version     : 1.0
* OS          : Windows 10
* Copyright   : This is my own original work
* Description : Program imports data from a CSV file and calculates the average test scores for each student
*               Input:  Button/keyboard clicks
*               Output: Contents of ListBox (test score averages)
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or unmodified. I have not given other fellow student(s) access to my program.         
***************************************************************/

namespace CSV_Reader
{
    public partial class CSVReader : Form
    {
        public CSVReader()
        {
            InitializeComponent();
        }

        private void GetScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputFile; //to read file
                string line; //to hold a line from file
                int count = 0; //student counter
                int total; //accumulator
                double average; //test score average

                //create a delimiter array
                char[] delim = { ',' };

                //open the CSV file
                inputFile = File.OpenText("Grades.csv");

                while (!inputFile.EndOfStream)
                {
                    //increment the student counter
                    count++;

                    //read a line from the file
                    line = inputFile.ReadLine();

                    //get the test scores as tokens
                    string[] tokens = line.Split(delim);

                    //set accumulator to 0
                    total = 0;

                    //calculate total of the test score tokens
                    foreach (string str in tokens)
                    {
                        if (int.TryParse(str, out int num)) //ensures input is number
                        {
                            total += num;
                        }
                        else
                        {
                            MessageBox.Show("Input was not a number."); //error message
                        }
                    }

                    //calculates average of these test scores
                    average = (double)total / tokens.Length;

                    //display average
                    averagesListBox.Items.Add("The average for student " + count + " is " + average.ToString("n1"));
                }

                //close the file
                inputFile.Close();
            }
            catch (Exception ex)
            {
                //display error message
                MessageBox.Show(ex.Message);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //closes form
            this.Close();
        }
    }
}
