<template>

  <div class="theme-bg-primary h-full">

    <!-- Header-->
    <main-header/>

    <!-- Content -->
    <article class="mt-[20px] bg-defaultBackground content-padding">

      <!-- Locations container -->
      <locations-container/>

    </article>

    <button class="mt-80" @click="appThemeService.toggleDarkMode()">Dark mode</button>

  </div>

</template>

<script setup lang="ts">
import MainHeader from "@/common/components/MainHeader.vue";
import { AppThemeService } from "@/infrastructures/service/AppThemeService";
import LocationsContainer from "@/modules/locations/components/ListingsContainer.vue";

const appThemeService = new AppThemeService();

</script>