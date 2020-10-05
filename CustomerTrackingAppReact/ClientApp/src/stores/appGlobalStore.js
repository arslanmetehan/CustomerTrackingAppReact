export const appGlobalStore = createStore({
    auth: {
        
        currentUser: {id: 0, username: "Guest"},
        setCurrentUser: action((state, payload) => {
            state.currentUser = payload;
        })
    }
});