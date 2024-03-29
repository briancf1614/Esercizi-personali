package com.xpgsolutions.aplicacionsinactivity.todoapp;

public sealed class TaskCategory permits TaskCategory.Personal, TaskCategory.Business, TaskCategory.Other {


    public non-sealed static class Personal extends TaskCategory{}
    public non-sealed static class Business extends TaskCategory{}
    public non-sealed static class Other extends TaskCategory{}

}



