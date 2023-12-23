<template>

  <div class="mt-[160px] grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-6 gap-x-4 gap-y-10 place-items-center">

    <listing-card v-for="listing in 20"/>

  </div>

</template>
<script setup lang="ts">
import ListingCard from "@/modules/locations/components/ListingCard.vue";
// import type { CallbackModel } from "@/infrastructures/models/CallbackModel";
import { ListingFilter } from "@/modules/locations/models/ListingFilter";
import type { Listing } from "@/modules/locations/models/Listing";
import {nextTick, onMounted, ref, watch} from "vue";
import {AirBnbApiClient} from "@/infrastructures/apiClients/airBnbApiClient/brokers/AirBnbApiClient";

const airBnbApiClient = new AirBnbApiClient();

const listings = ref<Array<Listing>>([]);

const pageSize = ref<number>(20);
const pageToken = ref<number>(1);

const props = defineProps({
  selectedCategoryId: {
    type: String,
    required: true
  }
});

const loadListingsAsync = async (categoryId: string) => {
  const categories = props.selectedCategoryId !== "" ? [props.selectedCategoryId] : [];
  const filter = new ListingFilter(pageSize.value, pageToken.value, categories);
  const response = await airBnbApiClient.listings.getAsync(filter);
  if (response.response) {
    listings.value = response.response;
  }
};

watch(() => props.selectedCategoryId, async () => {
  await loadListingsAsync(props.selectedCategoryId);
});

// onMounted(async () => {
//     await nextTick(async () => await loadListingsAsync(props.selectedCategoryId));
// })


</script>