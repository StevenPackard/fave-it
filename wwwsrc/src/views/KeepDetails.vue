<template>
  <div class="container-fluid">
    <div class="row justify-content-center mt-3">
      <div class="col-6 text-center">
        <h1>This is the Keep Details</h1>
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-11 border details-box border-dark">
        <div class="row justify-content-center mt-3">
          <div class="col-10 text-center">
            <img class="img-box" :src="keep.img" />
          </div>
        </div>
        <div class="row mt-3 justify-content-center">
          <div class="col-10 text-center">
            <h1>{{keep.name}}</h1>
            <h5>{{keep.description}}</h5>
          </div>
          <div class="col-7 border border-secondary text-center mt-3">
            <h3>Views: {{keep.views}} -- Keeps: {{keep.keeps}} -- Shares: {{keep.shares}}</h3>
          </div>
          <div class="col-12 text-center mt-2">
            <!-- <button class="btn btn-outline-primary" @click="showVaults = !showVaults">Add to Vault</button> -->
            <!-- <div class="row justify-content-center bg-white mt-3" v-if="showVaults">
              <vault v-for="vault in vaults" :key="vault.id" :vault="vault" />
            </div>-->

            <div class="dropdown my-2" v-if="$auth.isAuthenticated">
              <button
                class="btn-small btn-outline-primary dropdown-toggle"
                type="button"
                id="dropdownMenuButton"
                data-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
              >Add to vault</button>
              <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                <a
                  class="dropdown-item"
                  v-for="vault in vaults"
                  :key="vault.id"
                  href="#"
                  @click="addKeepToVault(vault.id)"
                >{{vault.name}}</a>
              </div>
            </div>
            <button class="btn btn-outline-danger" @click="deleteKeep">Delete Keep</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import vault from "../components/VaultComponent";
export default {
  name: "keep-details",
  beforeRouteLeave(to, from, next) {
    // just use `this`
    this.$store.state.KeepsStore.activeKeep = {};
    next();
  },
  data() {
    return {
      showVaults: false
    };
  },
  mounted() {
    this.$store.dispatch("getKeepById", this.$route.params.id);
    this.$store.dispatch("getMyVaults");
  },
  methods: {
    addKeepToVault(vaultId) {
      let newVaultKeep = { keepId: this.keep.id, vaultId: vaultId };
      this.$store.dispatch("addKeepToVault", {
        keep: this.keep,
        vaultKeep: newVaultKeep
      });
    },
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.$route.params.id);
    }
  },
  computed: {
    keep() {
      return this.$store.state.KeepsStore.activeKeep;
    },
    vaults() {
      return this.$store.state.VaultsStore.myVaults;
    }
  },
  components: {
    vault
  }
};
</script>

<style>
.details-box {
  height: 80vh;
}
.img-box {
  max-height: 400px;
}
</style>