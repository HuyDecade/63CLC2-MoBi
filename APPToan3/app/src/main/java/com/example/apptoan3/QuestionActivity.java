package com.example.apptoan3;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.view.View;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.Toast;

import com.example.apptoan3.Model.Question;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Locale;

public class QuestionActivity extends AppCompatActivity {

    private TextView textViewQuestion;
    private TextView textViewScore;
    private TextView getTextViewQuestionCount;
    private TextView textViewCategory;
    private TextView textViewCountDown;


    private RadioGroup rbGroup;
    private RadioButton rb1;
    private RadioButton rb2;
    private RadioButton rb3;
    private RadioButton rb4;

    private  RadioButton radioButtonConfirmNext;

    private CountDownTimer countDownTimer;
    private ArrayList<Question> questionsList;
    private  long timeLeftInmills;
    private int questionCounter;
    private int questionSize;

    private int Score;
    private boolean answered;
    private Question CurrentQuestion;

    private int count = 0;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_question);

        anhxa();

        Intent intent = getIntent();
        int categoryID = intent.getIntExtra("idcategories", 0);
        String categoryName = intent.getStringExtra("categoriesName");

        textViewCategory.setText("Chủ Đề" + categoryName);

        DataBase dataBase = new DataBase(this);
        questionsList = dataBase.getQuestion(categoryID);
        questionSize= questionsList.size();

        Collections.shuffle(questionsList);

        showNextQuestion();

        radioButtonConfirmNext.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (!answered){
                    if (rb1.isChecked() || rb2.isChecked()|| rb3.isChecked() || rb4.isChecked()) {
                        checkAnswer();
                    }
                    else {
                        Toast.makeText(QuestionActivity.this,"Hãy Chọn Đáp Án", Toast.LENGTH_SHORT).show();
                }
                }
                else {
                    showNextQuestion();
                }
            }

        });
    }

    private void showNextQuestion() {
        rb1.setTextColor(Color.BLACK);
        rb2.setTextColor(Color.BLACK);
        rb3.setTextColor(Color.BLACK);
        rb4.setTextColor(Color.BLACK);

        rbGroup.clearCheck();

        if (questionCounter<questionSize){
            CurrentQuestion = questionsList.get(questionCounter);

            textViewQuestion.setText(CurrentQuestion.getQuestion());

            rb1.setText(CurrentQuestion.getOption1());
            rb2.setText(CurrentQuestion.getOption2());
            rb3.setText(CurrentQuestion.getOption3());
            rb4.setText(CurrentQuestion.getOption4());

            questionCounter++;

            getTextViewQuestionCount.setText("Câu Hỏi"+questionCounter+"/"+questionSize);
            answered = false;

            radioButtonConfirmNext.setText("Xác Nhận");
            timeLeftInmills=30000;

            startCountDown();

        }
        else {
            finishQuestion();
        }

    }

    private void startCountDown() {
        countDownTimer = new CountDownTimer(timeLeftInmills,1000) {
            @Override
            public void onTick(long l) {
                timeLeftInmills= 1;

                updateCountDownText();

            }

            @Override
            public void onFinish() {
                timeLeftInmills = 0 ;
                updateCountDownText();

                checkAnswer();

            }
        }.start();
    }

    private void checkAnswer() {
        answered = true;

        RadioButton rbSelected = findViewById(rbGroup.getCheckedRadioButtonId());

        int anser = rbGroup.indexOfChild(rbSelected) + 1;
        if (anser ==CurrentQuestion.getAnswer()){
            Score = Score + 10;

            textViewScore.setText("Điểm " + Score);
        }

        showSolution();
    }

    private void showSolution() {
        rb1.setTextColor(Color.RED);
        rb2.setTextColor(Color.RED);
        rb3.setTextColor(Color.RED);
        rb4.setTextColor(Color.RED);

        switch (CurrentQuestion.getAnswer()){
            case 1 :
                 rb1.setTextColor(Color.GREEN);
                 textViewQuestion.setText("Đáp án là A");
                 break;
            case 2 :
                rb1.setTextColor(Color.GREEN);
                textViewQuestion.setText("Đáp án là B");
                break;
            case 3 :
                rb1.setTextColor(Color.GREEN);
                textViewQuestion.setText("Đáp án là C");
                break;
            case 4 :
                rb1.setTextColor(Color.GREEN);
                textViewQuestion.setText("Đáp án là D");
                break;
        }

        if (questionCounter<questionSize){
            radioButtonConfirmNext.setText("Câu Tiếp");
        }
        else {
            radioButtonConfirmNext.setText("Hoàn Thành");
        }
        countDownTimer.cancel();
    }


    private void updateCountDownText() {
        int minutes =(int) ((timeLeftInmills/1000)/60);
        int second =(int) ((timeLeftInmills/1000)%60);

        String timeFormatted= String.format(Locale.getDefault(),"%02d:%02d",minutes,second);

        textViewCountDown.setText(timeFormatted);

        if (timeLeftInmills<1000){
            textViewCountDown.setTextColor(Color.RED);
        }else {
            textViewCountDown.setTextColor(Color.BLACK);
        }


    }

    private void finishQuestion() {
        Intent resultIntent = new Intent();
        resultIntent.putExtra("Score", Score);
        setResult(RESULT_OK,resultIntent);
        finish();
    }

    public void onBackPressed() {

        count++;
        if (count>=1){
            finishQuestion();
        }
        count= 0;

        super.onBackPressed();
    }

    @SuppressLint("WrongViewCast")
    private void anhxa(){
        textViewQuestion = findViewById(R.id.text_view_question);
        textViewScore = findViewById(R.id.text_view_score);
        getTextViewQuestionCount= findViewById(R.id.text_view_question_count);
        textViewCategory = findViewById(R.id.text_view_category);

        textViewCountDown = findViewById(R.id.text_view_countdown);
        rbGroup = findViewById(R.id.radio_group);
        rb1 = findViewById(R.id.radio_button1);
        rb2 = findViewById(R.id.radio_button2);
        rb3 = findViewById(R.id.radio_button3);
        rb4 = findViewById(R.id.radio_button4);

       radioButtonConfirmNext = findViewById(R.id.button_confirm_next);
    }
}