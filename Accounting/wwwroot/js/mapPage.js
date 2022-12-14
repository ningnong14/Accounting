function mappage() {
    var mappage = [
        { menuCode: "MN001", menuURL: "/Serach" },
        { menuCode: "MN002", menuURL: "/RecordAccounting" }
    ];
    window.location.href = baseURL() + mappage.menuURL();
}