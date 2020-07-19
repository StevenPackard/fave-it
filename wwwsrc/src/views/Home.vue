<template>
  <div class="home container-fluid">
    <div class="row justify-content-center">
      <div class="col-5 bg-light text-center mt-3">
        <h2>Welcome to Keepr</h2>
      </div>
    </div>
    <div class="row mt-3 mx-2">
      <div class="card-columns">
        <keep v-for="keep in keeps" :key="keep.Id" :keep="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import keep from "../components/KeepComponent";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.KeepsStore.publicKeeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    keep
  }
};
</script>
<style scoped>
</style>
