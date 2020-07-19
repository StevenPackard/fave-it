<template>
  <div class="col-5 m-2 border border-dark">
    <router-link :to="{ path: `/vault/${vault.id}` }" @click="setActiveVault">
      <div>
        <h3>Name: {{vault.name}}</h3>
        <h3>Desc: {{vault.description}}</h3>
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