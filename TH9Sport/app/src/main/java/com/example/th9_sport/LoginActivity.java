package com.example.th9_sport;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class LoginActivity extends AppCompatActivity {

    private EditText editTextUsername;
    private EditText editTextPassword;
    private Button buttonLogin;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        editTextUsername = findViewById(R.id.editTextUsername);
        editTextPassword = findViewById(R.id.editTextPassword);
        buttonLogin = findViewById(R.id.buttonLogin);

        buttonLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Xử lý logic đăng nhập ở đây
                String username = editTextUsername.getText().toString();
                String password = editTextPassword.getText().toString();

                if (isValidLogin(username, password)) {
                    // Đăng nhập thành công
                    showToast("Login successful");
                } else {
                    // Đăng nhập thất bại
                    showToast("Invalid username or password");
                }
            }
        });
    }

    private boolean isValidLogin(String username, String password) {
        // Thực hiện kiểm tra đăng nhập ở đây (ví dụ: so sánh với dữ liệu trong cơ sở dữ liệu)
        // Trong ví dụ này, chúng ta giả sử đăng nhập luôn thành công
        return true;
    }

    private void showToast(String message) {
        Toast.makeText(this, message, Toast.LENGTH_SHORT).show();
    }
}
