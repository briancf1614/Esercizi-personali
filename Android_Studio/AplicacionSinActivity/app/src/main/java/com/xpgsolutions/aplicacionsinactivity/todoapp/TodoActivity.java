package com.xpgsolutions.aplicacionsinactivity.todoapp;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.app.Dialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;

import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.xpgsolutions.aplicacionsinactivity.R;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;


public class TodoActivity extends AppCompatActivity {

    private List<TaskCategory> categories = new ArrayList<>(Arrays.asList(
            new TaskCategory.Personal(),
            new TaskCategory.Business(),
            new TaskCategory.Other()
    ));

    private RecyclerView rvTasks;
    private RecyclerView rvCategories;
    private CategoriesAdapter categoriesAdapter;
    private TaskAdapter tasksAdapter;
    private FloatingActionButton fabAddTask;
    private List<Task> tasks = new ArrayList<>(Arrays.asList(
            new Task("PruebaBussiness", new TaskCategory.Business()),
            new Task("PruebaPersonal", new TaskCategory.Personal()),
            new Task("PruebaOther", new TaskCategory.Other())));

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_todo);

        initComponents();
        initUI();
        initListeners();
    }

    private void initListeners() {
        fabAddTask.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showDialog();
            }
        });
    }

    private void showDialog() {
        Dialog dialog = new Dialog(this);
        dialog.setContentView(R.layout.dialog_task);

        Button btnAddTask = dialog.findViewById(R.id.btnAddTask);
        EditText etTask = dialog.findViewById(R.id.etTask);
        RadioGroup rgCategories = dialog.findViewById(R.id.rgategories);

        btnAddTask.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String currentTask = etTask.getText().toString();
                if (!currentTask.isEmpty()){
                    int selectedId = rgCategories.getCheckedRadioButtonId();
                    RadioButton selectedRadioButton = rgCategories.findViewById(selectedId);

                    TaskCategory currentCategory = null;
                    String SelectedText = selectedRadioButton.getText().toString();

                    if (SelectedText == getString(R.string.todo_dialog_category_personal)) {
                        currentCategory = new TaskCategory.Personal();
                    } else if (SelectedText == getString(R.string.todo_dialog_category_business)) {
                        currentCategory = new TaskCategory.Business();
                    } else if (SelectedText == getString(R.string.todo_dialog_category_other)) {
                        currentCategory = new TaskCategory.Other();
                    }

                    tasks.add(new Task(currentTask, currentCategory));
                    updateTask();
                    dialog.hide();
                }
            }
        });
        dialog.show();
    }

    private void initUI() {

        categoriesAdapter = new CategoriesAdapter(categories);
        rvCategories.setLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.HORIZONTAL, false));
        rvCategories.setAdapter(categoriesAdapter);
        tasksAdapter = new TaskAdapter(tasks, new TaskAdapter.OnTaskSelectedListener() {
            @Override
            public void onTaskSelected(int position) {
                onItemSelected(position);
            }
        });
        rvTasks.setLayoutManager(new LinearLayoutManager(this));
        rvTasks.setAdapter(tasksAdapter);
    }

    private void initComponents() {
        rvCategories = findViewById(R.id.rvCategories);
        rvTasks = findViewById(R.id.rvTasks);
        fabAddTask = findViewById(R.id.fabAddTask);
    }
    private void updateTask(){
        tasksAdapter.notifyDataSetChanged();
    }

    private void onItemSelected(int position){
        Task task = tasks.get(position);
        task.setSelected(!task.getSelected());
        updateTask();

    }
}

