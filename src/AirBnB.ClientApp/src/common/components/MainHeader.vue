<template>

  <header
      class="w-full fixed h-20 top-0 z-10 flex justify-between items-center theme-bg-primary content-padding border-b theme-border">

    <!-- Logo -->
    <main-logo/>

    <!-- Locations menu -->
    <locations-menu/>

    <!-- Profile menu -->
    <profile-menu/>

    <!-- Locations filter -->
    <locations-filter :isMobile="true"/>

    <!-- Bottom border -->
    <div class="absolute border-b-2 border-borderSecondary"></div>

  </header>

</template>

<script setup lang="ts">

import MainLogo from "@/common/components/icons/MainLogo.vue";
import LocationsMenu from "@/modules/locations/components/ListingsMenu.vue";
import { AppThemeService } from "@/infrastructures/service/AppThemeService";
import ProfileMenu from "@/modules/identity/ProfileMenu.vue";
import LocationsFilter from "@/modules/locations/components/ListingsFilter.vue";


</script>