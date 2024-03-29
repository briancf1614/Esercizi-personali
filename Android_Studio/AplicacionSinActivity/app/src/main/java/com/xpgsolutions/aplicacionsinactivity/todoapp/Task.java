package com.xpgsolutions.aplicacionsinactivity.todoapp;

public class Task {


    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Boolean getSelected() {
        return isSelected;
    }

    public void setSelected(Boolean selected) {
        isSelected = selected;
    }

    private String name;
    private TaskCategory category;
    private Boolean isSelected = false;

    public Task(String name, TaskCategory category, Boolean isSelected) {
        this.name = name;
        this.category = category;
        this.isSelected = isSelected;
    }

    public Task(String name, TaskCategory category) {
        this(name, category, false);
    }


    public TaskCategory getCategory() {
        return category;
    }

    public void setCategory(TaskCategory category) {
        this.category = category;
    }
}

