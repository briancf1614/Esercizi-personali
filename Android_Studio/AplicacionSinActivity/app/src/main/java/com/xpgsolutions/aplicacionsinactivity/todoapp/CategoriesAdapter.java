package com.xpgsolutions.aplicacionsinactivity.todoapp;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.xpgsolutions.aplicacionsinactivity.R;

import java.util.List;

public class CategoriesAdapter extends RecyclerView.Adapter<CategoriesViewHolder> {

    public List<TaskCategory> categories;
    public CategoriesAdapter(List<TaskCategory> categories){
        this.categories= categories;
    }

    @NonNull
    @Override
    public CategoriesViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_task_category, parent,false);
        return new CategoriesViewHolder(view);
    }
    @Override
    public void onBindViewHolder(@NonNull CategoriesViewHolder holder, int position) {
        holder.render(categories.get(position));
    }

    @Override
    public int getItemCount() {
        return categories.size();
    }
}
