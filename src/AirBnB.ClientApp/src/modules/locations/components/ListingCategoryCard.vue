<template>

  <div class="h-[80px] min-w-[50px] flex flex-col justify-center items-center cursor-pointer group main-transition select-none"
       @click="emit('onCategorySelected', listingCategory.id)">

    <!-- Category image -->
    <img class="h-[24px] w-[24px] mb-2 primary-transition dark:invert"
         :class="isSelected ? 'selected-opacity' : 'opacity-40 select-opacity'"
         :src="listingCategory.imageUrl"
         :alt="`${listingCategory.name} image`"
    />

    <!-- Category name -->
    <h5 class="theme-text-primary text-xs font-medium select-opacity whitespace-nowrap primary-transition"
        :class="isSelected ? 'selected-opacity' : 'opacity-40 select-opacity'">
      {{ listingCategory.name }}
    </h5>

    <!-- Category underline -->
    <div class="mt-[10px] w-4/5 h-[2px] theme-bg-accent select-opacity primary-transition"
         :class="isSelected ? 'selected-opacity' : 'opacity-0 select-opacity'">
    </div>
  </div>

  <!--    <p v-if="isSelected">HI</p>-->

</template>

<script setup lang="ts">

import { computed, defineProps, defineEmits, watch } from "vue";
import {ListingCategory} from "@/modules/locations/models/ListingCategory";

/* region Emits and Props */

const props = defineProps({
  listingCategory: {
    type: ListingCategory,
    required: true
  },
  selectedCategoryId: {
    type: String,
    required: true
  },
});

const emit = defineEmits({
  onCategorySelected: (categoryId: string) => true
});

const isSelected = computed(() => props.selectedCategoryId === props.listingCategory.id);

/* endregion */

</script>