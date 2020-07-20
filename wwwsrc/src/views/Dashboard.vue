<template>
  <div class="dashboard container-fluid">
    <div class="row justify-content-center">
      <div class="col-6 text-center">
        <h2>My Vaults</h2>
        <button
          class="btn btn-outline-primary"
          @click="showVaultForm = !showVaultForm"
        >
          New Vault
        </button>
      </div>
    </div>
    <vaultForm v-if="showVaultForm" />
    <div class="row justify-content-center mt-5" v-if="vaults.length < 1">
      <div class="col-9 text-center">
        <h3>
          You dont have any vaults yet. Create a Vault to store your favorite
          Keeps in!
        </h3>
      </div>
    </div>
    <div class="row justify-content-center">
      <vault-component v-for="vault in vaults" :key="vault.id" :vault="vault" />
    </div>
  </div>
</template>

<script>
import vaultForm from "../components/VaultForm";
import vaultComponent from "../components/VaultComponent";
export default {
  name: "dashboard",
  data() {
    return {
      showVaultForm: false,
    };
  },
  mounted() {
    this.$store.dispatch("getMyVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.VaultsStore.myVaults;
    },
  },
  components: {
    vaultForm,
    vaultComponent,
  },
};
</script>

<style></style>
