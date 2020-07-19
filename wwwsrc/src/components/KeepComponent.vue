<template>
  <div
    class="card shadow"
    style="width: 18rem;"
    @click="$router.push({name: 'keep-details', params: {id: keep.id}})"
  >
    <img :src="keep.img" class="card-img-top" />
    <div class="card-body text-center">
      <h5 class="card-title">{{keep.name}}</h5>
      <p class="card-text">{{keep.description}}.</p>

      <p class="text-center">
        <i class="fas fa-eye"></i>
        : {{keep.views}}
        <i class="fas fa-box ml-2"></i>
        : {{keep.keeps}}
        <i class="fas fa-share ml-2"></i>
        : {{keep.shares}}
      </p>
      <button
        v-if="keep.vaultKeepId"
        class="btn btn-outline-danger"
        @click="removeFromVault"
      >Remove from Vault</button>
    </div>
  </div>
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
    },
    removeFromVault() {
      event.stopPropagation();
      let vaultKeepData = {
        vaultKeepId: this.keep.vaultKeepId,
        vaultId: this.vaultId
      };
      this.$store.dispatch("deleteVaultKeep", vaultKeepData);
    }
  },
  props: ["keep", "vaultId"]
};
</script>

<style>
</style>