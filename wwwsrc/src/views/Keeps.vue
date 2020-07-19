<template>
  <div class="container-fluid">
    <div class="row justify-content-center">
      <div class="col-12 text-center">
        <h1>My Keeps</h1>
      </div>
    </div>
    <div class="row">
      <div class="col text-center">
        <button class="btn btn-outline-primary" @click="showKeepForm = !showKeepForm">New Keep</button>
      </div>
      <div class="col-12" v-if="showKeepForm">
        <keepForm />
      </div>
    </div>
    <div class="row justify-content-center">
      <keep class="mx-2 my-2" v-for="keep in keeps" :key="keep.id" :keep="keep" />
    </div>
  </div>
</template>

<script>
import keep from "../components/KeepComponent";
import keepForm from "../components/KeepForm";
export default {
  name: "keeps",
  data() {
    return {
      showKeepForm: false
    };
  },
  mounted() {
    this.$store.dispatch("getMyKeeps");
  },
  computed: {
    keeps() {
      return this.$store.state.KeepsStore.myKeeps;
    }
  },
  components: {
    keep,
    keepForm
  }
};
</script>

<style>
</style>