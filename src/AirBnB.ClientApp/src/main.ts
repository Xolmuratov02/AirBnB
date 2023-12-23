import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import {AppThemeService} from "@/infrastructures/service/AppThemeService";

const appThemeService = new AppThemeService();

const app = createApp(App);

// Set app theme
appThemeService.setAppTheme();

app.mount('#app');