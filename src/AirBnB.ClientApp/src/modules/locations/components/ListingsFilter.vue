<template>

  <button class="h-10 w-10 ml-3 flex md:hidden justify-center items-center theme-border rounded-full theme-shadow hover-shadow-zero primary-transition"
          :class="{'hidden': !isMobile}">
    <svg class="h-4 w-4 theme-icon-primary stroke-[2px]"
         xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32"
         aria-hidden="true"
         role="presentation"
         focusable="false">
      <path fill="none"
            d="M7 16H3m26 0H15M29 6h-4m-8 0H3m26 20h-4M7 16a4 4 0 1 0 8 0 4 4 0 0 0-8 0zM17 6a4 4 0 1 0 8 0 4 4 0 0 0-8 0zm0 20a4 4 0 1 0 8 0 4 4 0 0 0-8 0zm0 0H3"></path>
    </svg>
  </button>

  <button class="h-12 w-auto ml-3 px-4 flex justify-center items-center gap-3 group theme-border rounded-lg " :class="{'hidden': isMobile}">
    <svg class="h-4 w-4 theme-icon-primary stroke-[2px]"
         xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32"
         aria-hidden="true"
         role="presentation"
         focusable="false">
      <path fill="none"
            d="M7 16H3m26 0H15M29 6h-4m-8 0H3m26 20h-4M7 16a4 4 0 1 0 8 0 4 4 0 0 0-8 0zM17 6a4 4 0 1 0 8 0 4 4 0 0 0-8 0zm0 20a4 4 0 1 0 8 0 4 4 0 0 0-8 0zm0 0H3"></path>
    </svg>
    <span class="theme-text-primary">Filters</span>
  </button>

</template>

<script setup lang="ts">

const props = defineProps({
  isMobile: {
    type: Boolean,
    required: true
  }
});

</script>