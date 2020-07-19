<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12 text-center">
        <h1>This is the vault page</h1>
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-10 text-center border border-dark bg-white">
        <h1>{{vault.name}}</h1>
        <p>{{vault.description}}</p>
      </div>
    </div>
    <div class="row justify-content-center">
      <keep class="m-2" v-for="keep in keeps" :key="keep.id" :keep="keep" />
    </div>
  </div>
</template>

<script>
import keep from "../components/KeepComponent";
export default {
  name: "vault-details",
  mounted() {
    this.$store.dispatch("getVaultById", this.$route.params.id);
    this.$store.dispatch("getKeepsByVaultId", this.$route.params.id);
  },
  computed: {
    vault() {
      return this.$store.state.VaultsStore.activeVault;
    },
    keeps() {
      return this.$store.state.VaultsStore.vaultKeeps;
    }
  },
  components: {
    keep
  }
};
</script>

<style>
</style>