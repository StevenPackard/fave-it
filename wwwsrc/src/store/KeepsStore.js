import Vue from "vue";
import router from "../router";
import { api } from "./AxiosService";

export const KeepsStore = {
  state: {
    publicKeeps: [],
    myKeeps: [],
    activeKeep: {},
  },

  mutations: {
    setPublicKeeps(state, keeps) {
      state.publicKeeps = keeps;
    },
    setActiveKeep(state, keep) {
      state.activeKeep = keep;
    },
    setKeepDetails(state, keep) {
      state.activeKeep = keep;
    },
    setMyKeeps(state, keeps) {
      state.myKeeps = keeps;
    },
  },

  actions: {
    async getPublicKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps");
        console.log(res.data);
        commit("setPublicKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getKeepById({ commit, dispatch }, keepId) {
      try {
        let res = await api.get("keeps/" + keepId);
        commit("setKeepDetails", res.data);
        dispatch("increaseKeepViews", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async increaseKeepViews({ commit, dispatch }, keep) {
      try {
        keep.views += 1;
        let res = await api.put("keeps/" + keep.id, keep);
        commit("setKeepDetails", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async addKeepToVault({ commit, dispatch }, keepData) {
      await api.post("vaultkeeps", keepData.vaultKeep);
      dispatch("increaseKeepKeeps", keepData.keep);
    },
    async increaseKeepKeeps({ commit, dispatch }, keep) {
      try {
        keep.keeps++;
        let res = await api.put("keeps/" + keep.id, keep);
        commit("setKeepDetails", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getMyKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps/my-keeps");
        commit("setMyKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },
  },
};
