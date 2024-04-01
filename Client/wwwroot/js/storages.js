storage = {
    session = {
        setItem: (key, value) => window.sessionStorage.setItem(key, value),
        getItem: key => window.sessionStorage.getItem(key),
        removeItem: key => window.sessionStorage.removeItem(key)
    }
}
