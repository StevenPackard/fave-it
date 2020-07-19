<template>
  <div class="container-fluid">
    <div class="row justify-content-center">
      <div class="col-12 text-center">
        <h1>My Keeps</h1>
      </div>
    </div>
    <div class="row justify-content-center">
      <keep class="mx-2 my-2" v-for="keep in keeps" :key="keep.id" :keep="keep" />
    </div>
  </div>
</template>

<script>
import keep from "../components/KeepComponent";
export default {
  name: "keeps",
  mounted() {
    this.$store.dispatch("getMyKeeps");
  },
  computed: {
    keeps() {
      return this.$store.state.KeepsStore.myKeeps;
    }
  },
  components: {
    keep
  }
};
</script>

<style>
</style>