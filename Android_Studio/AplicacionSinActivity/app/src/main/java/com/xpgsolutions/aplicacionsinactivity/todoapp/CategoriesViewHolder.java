package com.xpgsolutions.aplicacionsinactivity.todoapp;

import android.view.View;
import android.widget.TextView;

import androidx.core.content.ContextCompat;
import androidx.recyclerview.widget.RecyclerView;

import com.xpgsolutions.aplicacionsinactivity.R;

public class CategoriesViewHolder extends RecyclerView.ViewHolder {
    private TextView tvCategoryName;
    private View divider;

    /*Atencion a esta parte se deve meter entro el constructor y los valores meterlos afuera como private, como ya sabes hacer campi*/
    public CategoriesViewHolder(View view) {
        super(view);
        /*Asignacion de valores*/
        tvCategoryName = view.findViewById(R.id.tvcategoryName);
        divider = view.findViewById(R.id.divider);
    }

    public void render(TaskCategory taskCategory){
        if (taskCategory instanceof TaskCategory.Business) {
            tvCategoryName.setText("Negocios");
            divider.setBackgroundColor(ContextCompat.getColor(divider.getContext(),R.color.todo_business_category));
        } else if (taskCategory instanceof TaskCategory.Other) {
            tvCategoryName.setText("Otros");
            divider.setBackgroundColor(ContextCompat.getColor(divider.getContext(), R.color.todo_other_category));
        } else if (taskCategory instanceof TaskCategory.Personal) {
            tvCategoryName.setText("Personal");
            divider.setBackgroundColor(ContextCompat.getColor(divider.getContext(),R.color.todo_personal_category));
        }

    }
}
