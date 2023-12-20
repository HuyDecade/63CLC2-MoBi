package com.example.apptoan3;

import android.provider.BaseColumns;

public final class table {
    private table(){

    }

    public  static class CategoriesTable implements BaseColumns {

        //du lieu bang Categories
        public static final String TABLE_NAME= "Categories";
        public static final String COLUM_NAME= "name";
    }

    public  static class QuestionTable implements BaseColumns {

        //TEN BANG
        public static final String TABLE_NAME= "Question";

        //CAU HOI
        public static final String COLUM_QUESTION= "Question";

        // 4 DAP AN CHON
        public static final String COLUM_OPTION1= "Question1";
        public static final String COLUM_OPTION2= "Question2";
        public static final String COLUM_OPTION3= "Question3";
        public static final String COLUM_OPTION4= "Question4";

        //DAP AN
        public static final String COLUM_ANSWER= "Question";
        public static final String COLUM_CATEGORIES_ID= "id_categories";
    }
}
