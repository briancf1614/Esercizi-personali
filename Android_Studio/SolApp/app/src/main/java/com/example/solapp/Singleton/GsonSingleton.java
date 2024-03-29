package com.example.solapp.Singleton;

import com.google.gson.Gson;

public class GsonSingleton {
    private static Gson gsonInstance;
    private GsonSingleton(){}

    public static synchronized Gson getGsonInstance(){
        if (gsonInstance==null){
            gsonInstance = new Gson();
        }
        return gsonInstance;
    }
}
