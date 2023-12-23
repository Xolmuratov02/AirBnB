<template class="relative">

  <!-- Previous button -->
  <previous-button v-if="canScrollPrev" class="mb-3 theme-bg-primary hover-shadow-zero top-" @click="onPrevCategories"/>

  <div ref="scrollContainer" class="flex gap-6 md:gap-12 overflow-x-scroll no-scrollbar">
    <slot v-bind="$attrs"></slot>
  </div>

  <!-- Next button -->
  <next-button v-if="canScrollNext" class="mb-3 theme-bg-primary hover-shadow-zero" @click="onNextCategories"/>

</template>
<script setup lang="ts">
import { nextTick, onMounted, onUnmounted, type PropType, ref, watch } from "vue";
import PreviousButton from "@/common/components/PreviousButton.vue";
import NextButton from "@/common/components/NextButton.vue";
import { DocumentService } from "@/infrastructures/service/DocumentService";
import ListingCard from "@/modules/locations/components/ListingCard.vue";

const scrollContainer = ref<HTMLDivElement>();
const documentService = new DocumentService();

const props = defineProps({
  scrollChangeSource: {
    type: Array as PropType<Array<any>>,
    required: true
  },
  scrollDistance: {
    type: Number as PropType<number>,
    required: false,
    default: 450
  }
});

/* region Watchers and Computed properties */

const scrollPosition = ref<number>(0);
const canScrollPrev = ref<boolean>(true);
const canScrollNext = ref<boolean>(true);
const isMounted = ref<boolean>(false);
const firstComputed = ref<boolean>(false);

watch(() => [props.scrollChangeSource], () => {
  if (firstComputed.value) return;

  nextTick(() => {
    computeCanScroll();
    firstComputed.value = true;
  });
});

const computeCanScroll = () => {
  canScrollPrev.value = documentService.canScrollLeft(scrollContainer.value!);
  canScrollNext.value = documentService.canScrollRight(scrollContainer.value!);
};

onMounted(() => {
  if (!scrollContainer.value) return;

  documentService.addEventListener(scrollContainer.value, 'scroll', onScroll);

  isMounted.value = true;
});

onUnmounted(() => {
  if (!scrollContainer.value) return;

  documentService.removeEventListener(scrollContainer.value, 'scroll', onScroll);
});

/* endregion */

/* region Methods */

const onPrevCategories = () => {
  if (!scrollContainer.value) return;

  documentService.scrollLeft(scrollContainer.value, props.scrollDistance);
};

const onNextCategories = () => {
  if (!scrollContainer.value) return;

  documentService.scrollRight(scrollContainer.value, props.scrollDistance);
  // computeCanScroll();
};

/* endregion */

/* region Event listeners */

const onScroll = (target: HTMLElement) => {
  scrollPosition.value = target.scrollLeft;
  computeCanScroll();
};

/* endregion */

</script>