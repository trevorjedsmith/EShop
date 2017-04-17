/// <reference path="../../typings/globals/jquery/index.d.ts" />
var TheStoreCore;
(function (TheStoreCore) {
    var Data;
    (function (Data) {
        var TheStoreCoreDataService = (function () {
            function TheStoreCoreDataService(ajaxService, controllerName) {
                this.ajaxService = ajaxService;
                this.baseUri = "" + TheStoreCore.Constants.BaseServiceBusUrl + controllerName;
            }
            // GET api/{controller}
            TheStoreCoreDataService.prototype.Get = function () {
                var url = "" + this.baseUri;
                return this.ExecuteGet(url);
            };
            // GET api/{controller}/1
            TheStoreCoreDataService.prototype.GetById = function (id) {
                var url = this.baseUri + "/" + id;
                return this.ExecuteGet(url);
            };
            // POST api/{controller}
            TheStoreCoreDataService.prototype.Post = function (item) {
                var url = this.baseUri;
                return this.ExecutePost(url, item);
            };
            // PUT api/{controller}/5
            TheStoreCoreDataService.prototype.Put = function (item) {
                var url = this.baseUri + "/" + item.Id;
                return this.ExecutePut(url, item);
            };
            // DELETE api/{controller}/5
            TheStoreCoreDataService.prototype.Delete = function (id) {
                var dfd = this.ajaxService.Deferred();
                var config = {
                    url: "{this.baseUri}/{id}",
                    contentType: TheStoreCore.Constants.BaseContentType,
                    type: TheStoreCore.Constants.BaseDeleteMethod
                };
                var me = this;
                this.ajaxService.ajax(config)
                    .fail(function (xhr, textStatus, errorThrown) {
                    dfd.reject();
                })
                    .done(function (data) {
                    dfd.resolve(data);
                });
                return dfd.promise();
            };
            TheStoreCoreDataService.prototype.ExecuteGet = function (url, params) {
                var dfd = this.ajaxService.Deferred();
                var me = this;
                this.ajaxService
                    .get(url, params)
                    .fail(function (xhr) {
                    dfd.reject();
                })
                    .done(function (retVal) {
                    dfd.resolve(retVal);
                });
                return dfd.promise();
            };
            TheStoreCoreDataService.prototype.ExecutePost = function (url, item) {
                var dfd = this.ajaxService.Deferred();
                var payload = JSON.stringify(item), config = {
                    url: url,
                    contentType: TheStoreCore.Constants.BaseContentType,
                    type: TheStoreCore.Constants.BasePOSTMethod,
                    data: payload
                };
                var me = this;
                this.ajaxService.ajax(config)
                    .fail(function (xhr, textStatus, errorThrown) {
                    dfd.reject();
                })
                    .done(function (data) {
                    dfd.resolve(data);
                });
                return dfd.promise();
            };
            TheStoreCoreDataService.prototype.ExecutePut = function (url, item) {
                var dfd = this.ajaxService.Deferred();
                var payload = JSON.stringify(item), config = {
                    url: url,
                    contentType: TheStoreCore.Constants.BaseContentType,
                    type: TheStoreCore.Constants.BasePUTMethod,
                    data: payload
                };
                var me = this;
                this.ajaxService.ajax(config)
                    .fail(function (xhr, textStatus, errorThrown) {
                    dfd.reject();
                })
                    .done(function (data) {
                    dfd.resolve(data);
                });
                return dfd.promise();
            };
            return TheStoreCoreDataService;
        }());
        Data.TheStoreCoreDataService = TheStoreCoreDataService;
    })(Data = TheStoreCore.Data || (TheStoreCore.Data = {}));
})(TheStoreCore || (TheStoreCore = {}));
