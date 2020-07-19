<template>
  <div class="container-fluid">
    <div class="row justify-content-center mt-2">
      <!-- keep details -->
      <div class="col-6 border details-box bg-light shadow">
        <div class="row justify-content-center mt-3">
          <div class="col-7 text-center mt-3">
            <h3>
              <i class="fas fa-1x fa-eye icon-color"></i>
              : {{keep.views}}
              <img
                class="small-logo mb-1 ml-2"
                src="../assets/small-logo.png"
                alt
              />
              {{keep.keeps}}
              <i class="fas fa-1x fa-share ml-3 icon-color"></i>
              : {{keep.shares}}
            </h3>
          </div>
          <div class="col-10 text-center">
            <img class="img-box shadow" :src="keep.img" />
          </div>
        </div>
        <div class="row mt-3 justify-content-center">
          <div class="col-10 text-center">
            <h1>{{keep.name}}</h1>
            <h5>{{keep.description}}</h5>
          </div>
        </div>
      </div>
      <div class="col-5 text-center details-box bg-light ml-4 shadow">
        <h1>Interaction</h1>
        <div class="row">
          <div class="col-6 mt-2">
            <!-- <button class="btn btn-outline-primary" @click="showVaults = !showVaults">Add to Vault</button> -->
            <!-- <div class="row justify-content-center bg-white mt-3" v-if="showVaults">
              <vault v-for="vault in vaults" :key="vault.id" :vault="vault" />
            </div>-->
            <button class="btn btn-outline-danger" @click="deleteKeep">Delete Keep</button>
          </div>
          <div class="col-6">
            <div class="dropdown my-2" v-if="$auth.isAuthenticated">
              <button
                class="btn btn-outline-primary dropdown-toggle"
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
          </div>
        </div>
        <div class="row justify-content-center mt-5">
          <div class="col-11 bg-secondary comment-box">
            <h2>Comment section incoming</h2>
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
  max-height: 500px;
  max-width: 600px;
}
.icon-color {
  background: -webkit-linear-gradient(rgb(131, 206, 219), rgb(37, 47, 194));
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
}
.comment-box {
  height: 50vh;
}
</style> 