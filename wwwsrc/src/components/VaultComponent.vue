<template>
  <div class="col-4 m-2 border border-dark bg-light shadow text-center">
    <router-link :to="{ path: `/vault/${vault.id}` }" @click="setActiveVault">
      <div>
        <h3>{{vault.name}}</h3>
        <h5>{{vault.description}}</h5>
      </div>
    </router-link>
  </div>
</template>

<script>
export default {
  name: "vault-component",
  methods: {
    setActiveVault() {
      this.$store.commit("setActiveVault", this.vault);
    }
  },
  props: ["vault"]
};
</script>

<style>
</style>