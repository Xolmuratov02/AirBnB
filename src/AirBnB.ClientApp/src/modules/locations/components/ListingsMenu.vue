<template>

  <div
      class=" flex flex-grow md:grow-0 md:w-fit items-center pl-6 pr-2 gap-4 theme-bg-secondary theme-border theme-shadow hover-shadow rounded-full primary-transition">

    <!-- Listing menu detailed -->
    <div class="h-12 hidden md:flex items-center justify-center gap-5 theme-text-primary">

      <button class="text-sm font-medium line-clamp-1">
        <span class="line-clamp-1">Anywhere</span>
      </button>

      <div class="theme-border h-3/5"></div>

      <button class="text-sm font-medium ">
        <span class="line-clamp-1">Any week</span>
      </button>

      <div class="theme-border h-3/5"></div>

      <button class="text-sm gap-3 flex items-center justify-center theme-text-secondary">
                <span class="line-clamp-1">
                    Add guests
                </span>
        <span class="bg-logoPrimary h-[32px] w-[32px] flex items-center justify-center rounded-full text-white">
                    <svg xmlns="http://www.w3.org/2000/svg"
                         viewBox="0 0 32 32"
                         aria-hidden="true"
                         role="presentation"
                         focusable="false"
                         style="display: block; fill: none; height: 12px; width: 12px; stroke: currentcolor; stroke-width: 5.33333; overflow: visible;">
                        <path fill="none"
                              d="M13 24a11 11 0 1 0 0-22 11 11 0 0 0 0 22zm8-3 9 9"></path>
                    </svg>
                </span>
      </button>
    </div>

    <!-- Listing menu simple -->
    <button class="md:hidden flex items-center justify-center gap-3 h-12">

                <span class="h-[40px] w-[40px] flex items-center justify-center">
                    <svg class="w-[20px] h-[20px] theme-icon-primary stroke-[5px]"
                         width="20px" height="20px"
                         xmlns="http://www.w3.org/2000/svg"
                         viewBox="0 0 32 32"
                         aria-hidden="true"
                         role="presentation"
                         focusable="false">
                        <path fill="none"
                              d="M13 24a11 11 0 1 0 0-22 11 11 0 0 0 0 22zm8-3 9 9"></path>
                    </svg>
                </span>

      <span class="flex flex-col items-start">
                <span class="text-sm font-medium theme-text-primary">
                    <span>Anywhere</span>
                </span>
                <span class="flex gap-x-2 text-xs theme-text-secondary">
                    <span>Any week</span>
                    <span>•</span>
                    <span>Add guests</span>
                </span>
            </span>

    </button>
  </div>

</template>
<script setup lang="ts">
</script>