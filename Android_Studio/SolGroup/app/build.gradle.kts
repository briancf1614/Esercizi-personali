plugins {
    id("com.android.application")
}

android {
    namespace = "com.example.solgroup"
    compileSdk = 34

    defaultConfig {
        applicationId = "com.example.solgroup"
        minSdk = 24
        targetSdk = 34
        versionCode = 1
        versionName = "1.0"

        testInstrumentationRunner = "androidx.test.runner.AndroidJUnitRunner"
    }

    buildTypes {
        release {
            isMinifyEnabled = false
            proguardFiles(
                getDefaultProguardFile("proguard-android-optimize.txt"),
                "proguard-rules.pro"
            )
        }
    }
    compileOptions {
        sourceCompatibility = JavaVersion.VERSION_17
        targetCompatibility = JavaVersion.VERSION_17
    }
    buildToolsVersion = "30.0.2"
}

dependencies {

    //      Volley Dependencies
    implementation("com.android.volley:volley:1.2.1")

    //      Gson Dependecies
    implementation("com.google.code.gson:gson:2.10.1")

//    libreria di honeywell palmari
    implementation(files("../libs/DataCollection.aar"))


    implementation("androidx.appcompat:appcompat:1.6.1")
    implementation("com.google.android.material:material:1.10.0")
    implementation("androidx.constraintlayout:constraintlayout:2.1.4")
    testImplementation("junit:junit:4.13.2")
    androidTestImplementation("androidx.test.ext:junit:1.1.5")
    androidTestImplementation("androidx.test.espresso:espresso-core:3.5.1")
}