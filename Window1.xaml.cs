using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Media;

namespace Quiz
{
    public partial class Window1 : Window
    {
        public static string file_path_questions;
        public static string file_path_audio;
        public static int number_questions;
        public static string title;

        System.IO.StreamReader geography;
        int which_question = 0;
        string chosen;
        int score = 0;

        string[] questions;
        string[] answers;
        string[] corrects;

        Random random = new Random();
        int random_answers;
        int answerA, answerB, answerC, answerD;
        int correctA, correctB, correctC, correctD;
        int question_displayed;
        bool[] questions_were = new bool[number_questions];

        int number_line = 1;
        int counter_questions = 0;
        int counter_answers = 0;
        int counter_corrects = 0;
        string line;

        SoundPlayer audio = new SoundPlayer(file_path_audio);

        public void read_data()
        {
            questions = new string[100];
            answers = new string[400];
            corrects = new string[100];
            geography = new System.IO.StreamReader(file_path_questions);
            while ((line = geography.ReadLine()) != null)
            {
                if (number_line == 7) number_line = 1;
                switch (number_line)
                {
                    case 1:
                        questions[counter_questions] = line;
                        counter_questions++;
                        break;
                    case 2:
                        answers[counter_answers] = line;
                        counter_answers++;
                        break;
                    case 3:
                        answers[counter_answers] = line;
                        counter_answers++;
                        break;
                    case 4:
                        answers[counter_answers] = line;
                        counter_answers++;
                        break;
                    case 5:
                        answers[counter_answers] = line;
                        counter_answers++;
                        break;
                    case 6:
                        corrects[counter_corrects] = line;
                        counter_corrects++;
                        break;
                }
                number_line++;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            audio.Stop();
            audio.Dispose();
            Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        public void AnswerA(object sender, RoutedEventArgs e) 
        { 
            chosen = answers[correctA];
            if (chosen == corrects[question_displayed]) { MessageBox.Show("Dobrze!", "Wynik", MessageBoxButton.OK, MessageBoxImage.Information); score++; }
            else 
            { 
                MessageBox.Show("Źle...", "Wynik", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("Poprawna odpowiedź: " + corrects[question_displayed], "Poprawna", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            which_question++;
            Process();
        }
        public void AnswerB(object sender, RoutedEventArgs e)
        {
            chosen = answers[correctB];
            if (chosen == corrects[question_displayed]) { MessageBox.Show("Dobrze!", "Wynik", MessageBoxButton.OK, MessageBoxImage.Information); score++; }
            else
            {
                MessageBox.Show("Źle...", "Wynik", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("Poprawna odpowiedź: " + corrects[question_displayed], "Poprawna", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            which_question++;
            Process();
        }
        public void AnswerC(object sender, RoutedEventArgs e)
        {
            chosen = answers[correctC];
            if (chosen == corrects[question_displayed]) { MessageBox.Show("Dobrze!", "Wynik", MessageBoxButton.OK, MessageBoxImage.Information); score++; }
            else
            {
                MessageBox.Show("Źle...", "Wynik", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("Poprawna odpowiedź: " + corrects[question_displayed], "Poprawna", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            which_question++;
            Process();
        }
        public void AnswerD(object sender, RoutedEventArgs e)
        {
            chosen = answers[correctD];
            if (chosen == corrects[question_displayed]) { MessageBox.Show("Dobrze!", "Wynik", MessageBoxButton.OK, MessageBoxImage.Information); score++; }
            else
            {
                MessageBox.Show("Źle...", "Wynik", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("Poprawna odpowiedź: " + corrects[question_displayed], "Poprawna", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            which_question++;
            Process();
        }

        public void Process()
        {
            pbScore.Value = score;

            TextBlockTitle.Text = title;

            if (which_question == number_questions)
            {
                MessageBox.Show("Odpowiedziano dobrze na " + Convert.ToString(score) + "/" + number_questions + " pytań.",
                "Wynik końcowy", MessageBoxButton.OK, MessageBoxImage.Information);
                Application.Current.MainWindow.WindowState = WindowState.Normal;
                this.Close();
            }

            question_displayed = random.Next(number_questions);

            if (!(which_question == number_questions)) while (questions_were[question_displayed])
            {
                question_displayed = random.Next(number_questions);
            }
            questions_were[question_displayed] = true;

            random_answers = random.Next(4);
            if (random_answers == 0)
            {
                answerA = question_displayed * 4;
                answerB = question_displayed * 4 + 1;
                answerC = question_displayed * 4 + 2;
                answerD = question_displayed * 4 + 3;
                correctA = answerA;
                correctB = answerB;
                correctC = answerC;
                correctD = answerD;
            }
            else if (random_answers == 1)
            {
                answerD = question_displayed * 4;
                answerC = question_displayed * 4 + 1;
                answerB = question_displayed * 4 + 2;
                answerA = question_displayed * 4 + 3;
                correctD = answerD;
                correctC = answerC;
                correctB = answerB;
                correctA = answerA;
            }
            else if (random_answers == 2)
            {
                answerC = question_displayed * 4;
                answerD = question_displayed * 4 + 1;
                answerA = question_displayed * 4 + 2;
                answerB = question_displayed * 4 + 3;
                correctC = answerC;
                correctD = answerD;
                correctA = answerA;
                correctB = answerB;
            }
            else if (random_answers == 3)
            {
                answerB = question_displayed * 4;
                answerC = question_displayed * 4 + 1;
                answerD = question_displayed * 4 + 2;
                answerA = question_displayed * 4 + 3;
                correctB = answerB;
                correctC = answerC;
                correctD = answerD;
                correctA = answerA;
            }

            TextBlockQuestion.Text = which_question+1 + "/" + number_questions + ": " +  questions[question_displayed];
            btnAnswerA.Content = answers[answerA];
            btnAnswerB.Content = answers[answerB];
            btnAnswerC.Content = answers[answerC];
            btnAnswerD.Content = answers[answerD];
        }

        public Window1()
        {
            read_data();
            audio.Load();
            audio.PlayLooping(); 
            InitializeComponent();
            Process();
        }
    }
}
