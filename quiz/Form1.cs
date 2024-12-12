using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing; // ファイル操作のため

namespace quiz
{
    public partial class Form1 : Form
    {
        private List<int> questionIds;
        private int currentQuestionIndex;
        private int correctAnswers;
        private int totalQuestions = 10;
        private DataTable questionsTable;
        private string imageFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image");


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnOption1.Click += btnOption1_Click;
            btnOption2.Click += btnOption2_Click;
            btnOption3.Click += btnOption3_Click;
            btnOption4.Click += btnOption4_Click;

            btnOption1.Enabled = false;
            btnOption2.Enabled = false;
            btnOption3.Enabled = false;
            btnOption4.Enabled = false;
        }

        private void LoadQuestionsFromDatabase()
        {
            string connectionString = "Server=localhost;Database=Major;Uid=root;Pwd=0603;Pooling=true;";
            string query = @"SELECT Q.QuestionNo, Q.QuestionText, O.OptionNo, O.OptionText, O.Answer 
                              FROM Question Q 
                              JOIN QuestOption O ON Q.QuestionNo = O.QuestionNo";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    questionsTable = new DataTable();
                    adapter.Fill(questionsTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"データベースエラー: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InitializeQuiz()
        {
            questionIds = questionsTable.AsEnumerable()
                                         .Select(row => row.Field<int>("QuestionNo"))
                                         .Distinct()
                                         .ToList();

            Random random = new Random();
            questionIds = questionIds.OrderBy(x => random.Next()).Take(totalQuestions).ToList();

            currentQuestionIndex = 0;
            correctAnswers = 0;

            btnOption1.Enabled = true;
            btnOption2.Enabled = true;
            btnOption3.Enabled = true;
            btnOption4.Enabled = true;

            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            try
            {
                if (currentQuestionIndex >= questionIds.Count)
                {
                    MessageBox.Show($"クイズ終了！正解数: {correctAnswers}/{totalQuestions}", "結果");
                    btnOption1.Enabled = false;
                    btnOption2.Enabled = false;
                    btnOption3.Enabled = false;
                    btnOption4.Enabled = false;
                    return;
                }

                int questionId = questionIds[currentQuestionIndex];
                var questionRows = questionsTable.AsEnumerable()
                                                 .Where(row => row.Field<int>("QuestionNo") == questionId)
                                                 .ToList();

                DataRow questionRow = questionRows.First();

                // 問題と選択肢を表示
                lblQuestion.Text = questionRow["QuestionText"].ToString();
                btnOption1.Text = questionRows[0]["OptionText"].ToString();
                btnOption2.Text = questionRows[1]["OptionText"].ToString();
                btnOption3.Text = questionRows[2]["OptionText"].ToString();
                btnOption4.Text = questionRows[3]["OptionText"].ToString();

                lblScore.Text = $"正答数: {correctAnswers} / 出題数: {currentQuestionIndex + 1} / 問題総数: {totalQuestions}";

                // 画像を表示
                string imageFileName = GetImageFileName(questionId);
                string imagePath = Path.Combine(imageFolderPath, imageFileName);

                if (File.Exists(imagePath))
                {
                    pictureBox.Image = Image.FromFile(imagePath);
                }
                else
                {
                    pictureBox.Image = null; // 画像が見つからない場合
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DisplayQuestion エラー: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetImageFileName(int questionId)
        {
            var imageMapping = new Dictionary<int, string>
            {
                { 1, "nobunaga.png" },
                { 2, "french.jpg" },
                { 3, "chidorigafuti.jpg" },
                { 4, "amazon.jpg" },
                { 5, "fe.png" },
                { 6, "light.jpg" },
                { 7, "soccer.jpg" },
                { 8, "olympic.jpg" },
                { 9, "monalisa.jpg" },
                { 10, "nekodearu.jpg" },
                { 11, "baby-yoda.png" },
                { 12, "doraemon.png" },
                { 13, "matuzakaushi.jpg" },
                { 14, "pizapoteto.png" },
                { 15, "ace.png" }
            };

            return imageMapping.ContainsKey(questionId) ? imageMapping[questionId] : "default.jpg";
        }

        private void CheckAnswer(int selectedOption)
        {
            try
            {
                int questionId = questionIds[currentQuestionIndex];
                var questionRows = questionsTable.AsEnumerable()
                                                 .Where(row => row.Field<int>("QuestionNo") == questionId)
                                                 .ToList();

                DataRow selectedRow = questionRows.First(row => row.Field<int>("OptionNo") == selectedOption);

                if (selectedRow.Field<bool>("Answer"))
                {
                    correctAnswers++;
                    MessageBox.Show("正解です！", "結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("不正解です！", "結果", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                currentQuestionIndex++;

                if (currentQuestionIndex < questionIds.Count)
                {
                    DisplayQuestion();
                }
                else
                {
                    MessageBox.Show($"クイズ終了！正解数: {correctAnswers}/{totalQuestions}", "結果");
                    btnOption1.Enabled = false;
                    btnOption2.Enabled = false;
                    btnOption3.Enabled = false;
                    btnOption4.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CheckAnswer エラー: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOption1_Click(object sender, EventArgs e)
        {
            CheckAnswer(1);
        }

        private void btnOption2_Click(object sender, EventArgs e)
        {
            CheckAnswer(2);
        }

        private void btnOption3_Click(object sender, EventArgs e)
        {
            CheckAnswer(3);
        }

        private void btnOption4_Click(object sender, EventArgs e)
        {
            CheckAnswer(4);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            LoadQuestionsFromDatabase();
            InitializeQuiz();
        }
    }
}
