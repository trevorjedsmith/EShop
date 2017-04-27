var TheStoreCore;
(function (TheStoreCore) {
    var Constants = (function () {
        function Constants() {
        }
        return Constants;
    }());
    Constants.BaseServiceBusUrl = "http://localhost:51774/api/";
    Constants.BaseContentType = "application/json";
    Constants.BaseDeleteMethod = "DELETE";
    Constants.BasePOSTMethod = "POST";
    Constants.BasePUTMethod = "PUT";
    TheStoreCore.Constants = Constants;
})(TheStoreCore || (TheStoreCore = {}));
