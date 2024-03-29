package com.xpgsolutions.recyclerviewexample;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;

import com.xpgsolutions.recyclerviewexample.adapter.SuperHeroAdapter;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        initRecyclerView();


    }

    private void initRecyclerView() {
        RecyclerView recyclerView = findViewById(R.id.recyclerSuperhero);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
        recyclerView.setAdapter(new SuperHeroAdapter(SuperheroProvider.superheroes));
    }
}