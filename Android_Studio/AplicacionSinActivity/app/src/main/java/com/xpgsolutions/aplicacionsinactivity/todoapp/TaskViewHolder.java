package com.xpgsolutions.aplicacionsinactivity.todoapp;

import android.content.res.ColorStateList;
import android.graphics.Paint;
import android.view.View;
import android.widget.CheckBox;
import android.widget.TextView;

import androidx.core.content.ContextCompat;
import androidx.recyclerview.widget.RecyclerView;

import com.xpgsolutions.aplicacionsinactivity.R;

import java.util.Locale;

public class TaskViewHolder extends RecyclerView.ViewHolder {
    private TextView tvTask;
    private CheckBox cbTask;

    TaskViewHolder(View view) {
        super(view);
        tvTask = view.findViewById(R.id.tvTask);
        cbTask = view.findViewById(R.id.cbTask);
    }


    public void render(Task task) {

        if (task.getSelected()) {
            tvTask.setPaintFlags(tvTask.getPaintFlags() | Paint.STRIKE_THRU_TEXT_FLAG);
        } else {
            tvTask.setPaintFlags(tvTask.getPaintFlags() & ~Paint.STRIKE_THRU_TEXT_FLAG);
        }
        tvTask.setText(task.getName());
        cbTask.setChecked(task.getSelected());

        if (task.getCategory() instanceof TaskCategory.Business) {
            cbTask.setButtonTintList(ColorStateList.valueOf(ContextCompat.getColor(cbTask.getContext(), R.color.todo_business_category)));
        } else if (task.getCategory() instanceof TaskCategory.Personal) {
            cbTask.setButtonTintList(ColorStateList.valueOf(ContextCompat.getColor(cbTask.getContext(), R.color.todo_personal_category)));
        } else if (task.getCategory() instanceof TaskCategory.Other) {
            cbTask.setButtonTintList(ColorStateList.valueOf(ContextCompat.getColor(cbTask.getContext(), R.color.todo_other_category)));
        }


    }


}


