<template>

  <div class="fixed w-full top-0 pt-2 mt-20 z-10 flex items-center justify-center gap-4 content-padding theme-bg-primary">

    <horizontal-scroll :scrollChangeSource="listingCategories" class="relative" v-bind="$attrs">
      <listing-category-card v-for="listingCategory in listingCategories"
                             v-bind="$attrs"
                             :listingCategory="listingCategory as ListingCategory"
                             :selectedCategoryId="selectedCategoryId"
                             :index="listingCategory.id"
                             @onCategorySelected="onCategorySelected"/>
    </horizontal-scroll>

    <!-- Filters actions -->
    <div class="w-[500px] hidden lg:flex items-center justify-center pb-3">

      <!-- Locations filter -->
      <listings-filter :isMobile="false"/>

      <button class="ml-3 flex group h-12 w-auto px-4 theme-border justify-center items-center rounded-lg gap-3 theme-text-primary">
        <span class="text-xs font-medium whitespace-nowrap">Display total before taxes</span>
      </button>
    </div>

  </div>

</template>


<script setup lang="ts">
import { defineEmits, defineProps } from "vue";
import ListingsFilter from "@/modules/locations/components/ListingsFilter.vue";
import { ListingCategory } from "@/modules/locations/models/ListingCategory";
import ListingCategoryCard from "@/modules/locations/components/ListingCategoryCard.vue";
import HorizontalScroll from "@/common/components/HorizontalScroll.vue";

const props = defineProps({
  listingCategories: {
    type:  Array<ListingCategory>,
    required: true
  },
  selectedCategoryId: {
    type: String,
    required: true
  }
});

/* region Emits and Props */

const emit = defineEmits({
  onCategorySelected: (categoryId: string) => true
});

/* endregion */

/* region Event handlers */

const onCategorySelected = async (categoryId: string) => {
  emit('onCategorySelected', categoryId);
}

/* endregion */

</script>