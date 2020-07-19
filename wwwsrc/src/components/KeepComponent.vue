<template>
  <router-link :to="{ path: `/keep/${keep.id}` }" @click="setActiveKeep">
    <div class="card shadow" style="width: 18rem;">
      <img :src="keep.img" class="card-img-top" />
      <div class="card-body text-center">
        <h5 class="card-title">{{keep.name}}</h5>
        <p class="card-text">{{keep.description}}.</p>

        <p class="text-center">V: {{keep.views}} - K: {{keep.keeps}} - S: {{keep.shares}}</p>
      </div>
    </div>
  </router-link>
</template>

<script>
export default {
  name: "keep-component",
  mounted() {
    this.$store.dispatch("getMyVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.VaultsStore.myVaults;
    }
  },
  methods: {
    setActiveKeep() {
      this.$store.commit("setActiveKeep", this.keep);
    }
  },
  props: ["keep"]
};
</script>

<style>
</style>