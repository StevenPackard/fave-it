<template>
  <div class="container-fluid">
    <div class="row justify-content-center mt-4 mb-2">
      <div class="col-10 text-center border border-dark bg-white">
        <h1>{{vault.name}}</h1>
        <p>{{vault.description}}</p>
        <button class="btn btn-danger my-2" @click="deleteVault">Delete Vault</button>
      </div>
    </div>
    <div class="row mr-3">
      <div class="card-columns">
        <keep class="m-2" v-for="keep in keeps" :key="keep.id" :keep="keep" :vaultId="vault.id" />
      </div>
    </div>
  </div>
</template>

<script>
import keep from "../components/KeepComponent";
export default {
  name: "vault-details",
  beforeRouteLeave(to, from, next) {
    this.$store.state.VaultsStore.activeVault = {};
    next();
  },
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
  methods: {
    deleteVault() {
      this.$store.dispatch("deleteVault", this.$route.params.id);
    }
  },
  components: {
    keep
  }
};
</script>

<style>
</style>