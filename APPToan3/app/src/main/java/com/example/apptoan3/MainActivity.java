package com.example.apptoan3;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.TextView;

import com.example.apptoan3.Model.Category;

import java.util.List;

public class MainActivity extends AppCompatActivity {


    private TextView textViewHighScore;
    private Spinner spinnerCategory;
    private Button buttonStartQuestion;

    private int highScore;

    private static final int REQUEST_CODE_QUESTION = 1;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        AnhXa();

        loadHighScore();

        //load chu de
        loadCategories();
        // click de bat dau
        buttonStartQuestion.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                startQuestion();

            }
        });
    }

    private void loadHighScore() {
        SharedPreferences preferences =     getSharedPreferences("share",MODE_PRIVATE);
        highScore = preferences.getInt("highScore",0);
        textViewHighScore.setText("Điểm Cao" + highScore);
    }

    //ham bat dau cau hoi qua activity Question
    private void startQuestion() {
        //lay id, name, chu de
        Category category = (Category) spinnerCategory.getSelectedItem();
        int categoryId = category.getId();
        String categoryName = category.getName();
        Intent intent = new Intent(MainActivity.this, QuestionActivity.class);
        //gui du lieu name,id
        intent.putExtra("idCategories",categoryId);
        intent.putExtra("categoriesName", categoryName);

        startActivityForResult(intent,REQUEST_CODE_QUESTION);

    }


    // phuowng thuc anh xa
        private void AnhXa(){
        textViewHighScore = findViewById(R.id.textview_high_score);
        buttonStartQuestion = findViewById(R.id.button_start_question);
        spinnerCategory = findViewById(R.id.spinner_category);
        }

        //Lay du lieu danh sach chu de
    private void loadCategories(){
        DataBase dataBase = new DataBase(this);
        //Lay danh sach chu de
        List<Category> categories = dataBase.getDataCategories();

        //Tao Adapter
        ArrayAdapter<Category> categoryArrayAdapter = new ArrayAdapter<>(this,
                android.R.layout.simple_list_item_1,categories);
        //bo cuc hien thi chu de
        categoryArrayAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        // gan chu de spiner de hien thi
        spinnerCategory.setAdapter(categoryArrayAdapter);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if (requestCode == REQUEST_CODE_QUESTION){
            if (resultCode==RESULT_OK){
                int score = data.getIntExtra("Score",0);
                
                if (score>highScore){
                    updateHighScore(score);
                }
            }
        }
    }

    private void updateHighScore(int score) {
        highScore = score;

        textViewHighScore.setText("Điểm Cao " + highScore);
        SharedPreferences preferences = getSharedPreferences("share",MODE_PRIVATE);
        SharedPreferences.Editor editor = preferences.edit();

        editor.putInt("highScore", highScore);
        editor.apply();
    }
}