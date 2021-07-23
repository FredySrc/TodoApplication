function register_search() {
    const search = document.getElementById('txtSearch').value;

    const currentUrl = window.location.href.substring(
        window.location.href.lastIndexOf('/') + 1
    ).split('?')[0];

    window.location = `${currentUrl}?search=${search}`;
}

const register_input_search = document.getElementById('txtSearch');
register_input_search.addEventListener('keyup', function (event) {
    if (event.keyCode === 13) {
        event.preventDefault();
        register_search();
    }
});
