(function() {
    /* Copyright 2010 Google Inc. */
    
    if (!("google" in window)) {
        window.google = {}
    }
    if (!("earth" in window.google)) {
        window.google.earth = {}
    }
    ;
    if (!("google" in window)) {
        window.google = {}
    }
    if (!("idlglue" in window.google)) {
        window.google.idlglue = {}
    }
    window.google.idlglue.BROWSER_FIREFOX = "ff";
    window.google.idlglue.BROWSER_IE = "ie";
    window.google.idlglue.BROWSER_MOZILLA = "moz";
    window.google.idlglue.BROWSER_OPERA = "opera";
    window.google.idlglue.BROWSER_NETSCAPE = "netscape";
    window.google.idlglue.BROWSER_CHROME = "chrome";
    window.google.idlglue.BROWSER_SAFARI = "safari";
    window.google.idlglue.BROWSER_GOOGLE_EARTH = "google earth";
    window.google.idlglue.supportsNpapi = 
    function(a) {
        var b = window.google.idlglue;
        return a == b.BROWSER_FIREFOX || a == b.BROWSER_MOZILLA || a == b.BROWSER_NETSCAPE || a == b.BROWSER_CHROME || a == b.BROWSER_OPERA || a == b.BROWSER_SAFARI || a == b.BROWSER_GOOGLE_EARTH
    };
    window.google.idlglue.PLATFORM_MAC = "mac";
    window.google.idlglue.PLATFORM_LINUX = "linux";
    window.google.idlglue.PLATFORM_WINDOWS = "windows";
    window.google.idlglue.PLUGIN_MAIN_CLSID = "F9152AEC-3462-4632-8087-EEE3C3CDDA24";
    window.google.idlglue.PLUGIN_MAIN_MIMETYPE = "application/geplugin";
    window.google.idlglue.findAvailableId = 
    function(a) {
        var b = null;
        for (var d = 0; d < 100; d++) {
            var e = a + d;
            if (!document.getElementById(e)) {
                b = e
            }
        }
        return b
    };
    window.google.idlglue.getPlatform = function() {
        var a = navigator.userAgent;
        if (a.indexOf("Windows") >= 0) {
            return window.google.idlglue.PLATFORM_WINDOWS
        }
        if (a.indexOf("Macintosh") >= 0) {
            return window.google.idlglue.PLATFORM_MAC
        }
        if (a.indexOf("Linux") >= 0) {
            return window.google.idlglue.PLATFORM_LINUX
        }
        return null
    };
    window.google.idlglue.getBrowser = function() {
        var a = navigator.appName, b = navigator.userAgent, d = window.google.idlglue, 
        e = d.getPlatform();
        if (b.indexOf("Google Earth") >= 0) {
            return d.BROWSER_GOOGLE_EARTH
        } else if (b.indexOf("Opera") >= 0) {
            return d.BROWSER_OPERA
        } else if (b.indexOf("Firefox") >= 0 || b.indexOf("Minefield") >= 0) {
            return d.BROWSER_FIREFOX
        } else if (b.indexOf("Chrome") >= 0) {
            return d.BROWSER_CHROME
        } else if (b.indexOf("Safari") >= 0) {
            return d.BROWSER_SAFARI
        } else if (a.indexOf("Internet Explorer") >= 0) {
            return d.BROWSER_IE
        } else if (a.indexOf("Mozilla") >= 0) {
            return d.BROWSER_MOZILLA
        } else if (a.indexOf("Netscape") >= 0) {
            return d.BROWSER_NETSCAPE
        }
        return null
    };
    window.google.idlglue.getIeMajorVersion = function() {
        var a = navigator.userAgent, b = a.indexOf("MSIE ");
        if (b == -1) {
            return 0
        } else {
            return parseInt(a.substring(b + 5, a.indexOf(";", b)), 10)
        }
    };
    window.google.idlglue.isSupportedPlatform = function(a) {
        var b = window.google.idlglue;
        return a == b.PLATFORM_WINDOWS || a == b.PLATFORM_MAC
    };
    window.google.idlglue.isDeprecatedPlatform = function() {
        var a = navigator.userAgent, b = a.indexOf("PPC Mac") >= 0, d = false, e = /Mac OS X 10[_.]4[^0-9]/, f = e.exec(a), d = f && f.length > 0;
        return b || d
    };
    window.google.idlglue.isSupportedBrowser = 
    function(a, b) {
        var d = window.google.idlglue;
        if (a == d.PLATFORM_WINDOWS) {
            return b == d.BROWSER_FIREFOX || b == d.BROWSER_IE || b == d.BROWSER_CHROME || b == d.BROWSER_MOZILLA || b == d.BROWSER_NETSCAPE || b == d.BROWSER_OPERA || b == d.BROWSER_GOOGLE_EARTH
        } else if (a == d.PLATFORM_MAC) {
            return b == d.BROWSER_FIREFOX || b == d.BROWSER_SAFARI || b == d.BROWSER_CHROME || b == d.BROWSER_OPERA || b == d.BROWSER_GOOGLE_EARTH
        } else if (a == d.PLATFORM_LINUX) {
            return b == d.BROWSER_FIREFOX || b == d.BROWSER_MOZILLA
        }
        return false
    };
    window.google.idlglue.isSupported = function() {
        var a = 
        document.location.hash;
        if (a.indexOf("geplugin_browserok") != -1)
            return true;
        var b = window.google.idlglue, d = b.getPlatform(), e = b.getBrowser();
        if (b.isSupportedPlatform(d) && b.isSupportedBrowser(d, e)) {
            return true
        }
        return false
    };
    window.google.idlglue.logCsi = function(a, b, d, e) {
        var f = window.location.protocol == "https:";
        window.google.idlglue.logCsi2(a, b, f, d, e)
    };
    window.google.idlglue.logCsi2 = function(a, b, d, e, f) {
        if (e.length) {
            var c = "";
            for (var i = 0; i < e.length; i++) {
                var g = e[i];
                if (i > 0) {
                    c += ","
                }
                c += g[0] + "." + g[1]
            }
            var l = "http://csi.gstatic.com/csi";
            if (d) {
                l = "https://www.google.com/csi"
            }
            var h = l + "?v=2&s=" + a + "&rls=" + b + "&it=" + c;
            if (f) {
                h += "&" + f
            }
            window.google.idlglue.createImageForLogging(h)
        }
    };
    window.google.idlglue.createImageForLogging = function(a) {
        var b = new Image, d = window.google.idlglue.createImageForLogging.n++;
        window.google.idlglue.createImageForLogging.g[d] = b;
        b.onload = (b.onerror = function() {
            delete window.google.idlglue.createImageForLogging.g[d]
        });
        b.src = a;
        b = null
    };
    window.google.idlglue.createImageForLogging.g = {};
    window.google.idlglue.createImageForLogging.n = 
    0;
    window.google.idlglue.showError = function(a, b, d) {
        var e = window.google.idlglue;
        if (!a.pluginDiv) {
            return
        }
        a.pluginDiv.style.left = "" + -screen.width * 2 + "px";
        a.pluginDiv.style.top = "" + -screen.height * 2 + "px";
        a.messageDiv.style.display = "";
        var f = "";
        if (d) {
            f = "&detail=" + encodeURIComponent(d)
        }
        a.messageDiv.innerHTML = '<iframe src="' + a.errorUrl + "#error=" + encodeURIComponent(b) + f + '" width="100%" height="100%" frameborder=0></iframe>';
        e.doErrorCleanup(a)
    };
    window.google.idlglue.doErrorCleanup = function(a) {
        var b = a.errorCleanupCallbacks;
        if (b) {
            for (var d = 0; d < b.length; d++) {
                b[d]()
            }
            a.errorCleanupCallbacks = null
        }
        if (a.pluginDiv.parentNode == a.positioningDiv) {
            a.positioningDiv.removeChild(a.pluginDiv)
        }
        a.iface = null;
        a.div = null;
        a.pluginDiv = null
    };
    window.google.idlglue.createPluginAsInnerHTML = function(a, b, d) {
        var e = window.google.idlglue;
        if (window.google.idlglue.supportsNpapi(a)) {
            b.innerHTML = '<embed type="' + e.PLUGIN_MAIN_MIMETYPE + '" style="margin:0px; padding:0px; width:100%; height:100%;"></embed>';
            return true
        } else if (a == e.BROWSER_IE) {
            b.innerHTML = 
            '<object id="' + d + '" classid="CLSID:' + e.PLUGIN_MAIN_CLSID + '" style="margin:0px; padding:0px; width:100%; height:100%;"></object>';
            return true
        }
        b.innerHTML = "<div></div>";
        return false
    };
    window.google.idlglue.addErrorCleanupCallback = function(a, b) {
        if (!a.errorCleanupCallbacks) {
            a.errorCleanupCallbacks = []
        }
        a.errorCleanupCallbacks.push(b)
    };
    window.google.idlglue.create = function(a, b, d, e) {
        var f = window.google.idlglue;
        e = e || {};
        var c = f.getBrowser(), i = f.getPlatform(), g = f.isSupported(), l = (new Date).getTime(), h = document.createElement("div");
        h.style.position = "relative";
        h.style.width = "100%";
        h.style.height = "100%";
        h.style.overflow = "hidden";
        a.appendChild(h);
        if (i == f.PLATFORM_MAC) {
            var j = document.createElement("div");
            j.style.position = "absolute";
            j.style.width = "100%";
            j.style.height = "100%";
            j.style.background = "#FFF";
            h.appendChild(j)
        }
        var m = document.createElement("div"), n = m.style;
        n.position = "relative";
        n.width = "100%";
        n.height = "100%";
        n.background = "#E5E3DF url(" + window.google.earth.l + ") no-repeat scroll 50% 50%";
        h.appendChild(m);
        var o = document.createElement("div");
        n = o.style;
        n.position = "relative";
        n.left = "" + -screen.width * 2 + "px";
        n.top = "" + -screen.height * 2 + "px";
        n.width = "100%";
        n.height = "100%";
        h.appendChild(o);
        var k = {};
        k.div = o;
        k.pluginDiv = o;
        k.divInner = o;
        k.topDiv = a;
        k.positioningDiv = h;
        k.messageDiv = m;
        k.platform = i;
        k.browser = c;
        k.errorUrl = d;
        k.startLoadingTime = l;
        var p = f.findAvailableId("__idlglue_plugin__");
        if (!p) {
            f.showError(k, "ERR_NO_AVAILABLE_ID", "");
            return null
        }
        k.pluginId = p;
        o.id = "_idlglue_pluginDiv_" + p;
        if (g && !f.isInstalled() && !f.isDeprecatedPlatform()) {
            if (e.skipDownloadButton) {
                if (e.autoDownload == 
                undefined || e.autoDownload) {
                    f.showError(k, "INSTALLING", "")
                } else {
                    f.showError(k, "VIEW_INSTALLING", "")
                }
            } else {
                f.showError(k, "ERR_NOT_INSTALLED", "")
            }
            b(null);
            return
        }
        if (!f.isInstalled() && f.isDeprecatedPlatform()) {
            f.showError(k, "ERR_UNSUPPORTED_PLATFORM", "");
            b(null);
            return
        }
        if (!g && (!i || !f.isSupportedPlatform(i))) {
            f.showError(k, "ERR_UNSUPPORTED_PLATFORM", "");
            b(null);
            return
        }
        if (!g || !f.createPluginAsInnerHTML(c, o, p)) {
            f.showError(k, "ERR_UNSUPPORTED_BROWSER", "");
            b(null);
            return
        }
        var s = function(q, v) {
            window.setTimeout(function() {
                q.iface = 
                v.firstChild;
                if (!("getSelf" in q.iface)) {
                    f.showError(q, "ERR_CREATE_PLUGIN", "");
                    b(null)
                } else {
                    b(q)
                }
            }, 1)
        };
        s(k, o)
    };
    window.google.idlglue.getPluginContainerNode = function(a) {
        if (!a || !("getDiv_" in a)) {
            return null
        }
        var b = a.getDiv_();
        return b.parentNode.parentNode
    };
    window.google.idlglue.isInstalled = function() {
        try {
            var a = window.google.idlglue, b = a.getBrowser();
            if (window.google.idlglue.supportsNpapi(b)) {
                var d = navigator.mimeTypes[a.PLUGIN_MAIN_MIMETYPE];
                if (d && d.enabledPlugin) {
                    return true
                }
            } else if (b == a.BROWSER_IE) {
                var e = 
                document.createElement("div"), f = a.findAvailableId("isInstalled_test");
                if (a.createPluginAsInnerHTML(b, e, f)) {
                    return e.firstChild.getSelf() != null
                }
            }
        } catch (c) {
        }
        return false
    };
    window.google.earth.ErrorCode = {ERR_OK: "ERR_OK",ERR_DESTROYED: "ERR_DESTROYED",ERR_CREATE_PLUGIN: "ERR_CREATE_PLUGIN",ERR_INVALID_DIV: "ERR_INVALID_DIV",ERR_NO_AVAILABLE_ID: "ERR_NO_AVAILABLE_ID",ERR_UNSUPPORTED_BROWSER: "ERR_UNSUPPORTED_BROWSER",ERR_UNSUPPORTED_PLATFORM: "ERR_UNSUPPORTED_PLATFORM",ERR_MAX_EARTH_PROCESSES: "ERR_MAX_EARTH_PROCESSES",ERR_SHUTOFF: "ERR_SHUTOFF",ERR_NOT_INSTALLED: "ERR_NOT_INSTALLED",ERR_INIT: "ERR_INIT",ERR_VERSION: "ERR_VERSION",ERR_API_KEY: "ERR_API_KEY",ERR_EARTH_NOT_READY: "ERR_EARTH_NOT_READY",
        ERR_BRIDGE: "ERR_BRIDGE",ERR_CREATE_EARTH: "ERR_CREATE_EARTH",ERR_CREATE_CONNECT_MUTEX: "ERR_CREATE_CONNECT_MUTEX",ERR_EARTH_CONNECT_TIMEOUT: "ERR_EARTH_CONNECT_TIMEOUT",ERR_BRIDGE_OTHER_SIDE_PROBLEM: "ERR_BRIDGE_OTHER_SIDE_PROBLEM",ERR_BRIDGE_TIMEOUT: "ERR_BRIDGE_TIMEOUT",ERR_PLUGIN_NOT_READY: "ERR_PLUGIN_NOT_READY",ERR_BAD_URL: "ERR_BAD_URL",ERR_DATABASE_LOGIN_FAILURE: "ERR_DATABASE_LOGIN_FAILURE",ERR_INVALID_LANGUAGE: "ERR_INVALID_LANGUAGE"};
    window.google.earth.ErrorCodeToString = {0: "ERR_OK",1: "ERR_DESTROYED",
        100: "ERR_CREATE_PLUGIN",101: "ERR_INVALID_DIV",102: "ERR_NO_AVAILABLE_ID",103: "ERR_UNSUPPORTED_BROWSER",104: "ERR_UNSUPPORTED_PLATFORM",105: "ERR_MAX_EARTH_PROCESSES",106: "ERR_SHUTOFF",107: "ERR_NOT_INSTALLED",200: "ERR_INIT",201: "ERR_VERSION",202: "ERR_API_KEY",203: "ERR_EARTH_NOT_READY",300: "ERR_BRIDGE",301: "ERR_CREATE_EARTH",302: "ERR_CREATE_CONNECT_MUTEX",303: "ERR_EARTH_CONNECT_TIMEOUT",304: "ERR_BRIDGE_OTHER_SIDE_PROBLEM",305: "ERR_BRIDGE_TIMEOUT",400: "ERR_PLUGIN_NOT_READY",401: "ERR_BAD_URL",402: "ERR_DATABASE_LOGIN_FAILURE",
        403: "ERR_INVALID_LANGUAGE"};
    (function() {
        function a(c, i, g, l) {
            var h = this;
            h.left = c != undefined ? c : -1;
            h.top = i != undefined ? i : -1;
            h.width = g != undefined ? g : -1;
            h.height = l != undefined ? l : -1
        }
        function b(c) {
            var i = c.offsetWidth, g = c.offsetHeight;
            if (c.getBoundingClientRect) {
                var l = c.getBoundingClientRect(), h = l.left, j = l.top, m = c.ownerDocument;
                h += Math.max(m.documentElement.scrollLeft, m.body.scrollLeft);
                j += Math.max(m.documentElement.scrollTop, m.body.scrollTop);
                h += -m.documentElement.clientLeft;
                j += -m.documentElement.clientTop;
                return new a(h, j, i, g)
            }
            var h = 
            0, j = 0;
            while (c) {
                h += c.offsetLeft;
                j += c.offsetTop;
                try {
                    c = c.offsetParent
                } catch (n) {
                    c = c.parentNode
                }
            }
            return new a(h, j, i, g)
        }
        function d(c) {
            var i = false;
            while (c) {
                if (c == document) {
                    return true
                }
                var g;
                if ("getComputedStyle" in window) {
                    g = window.getComputedStyle(c, "")
                } else if ("currentStyle" in c) {
                    g = c.currentStyle
                } else {
                    g = c.style
                }
                if (g.display == "none") {
                    return false
                }
                if (!i) {
                    if (g.visibility == "hidden") {
                        return false
                    } else if (g.visibility == "visible") {
                        i = true
                    }
                }
                c = c.parentNode
            }
            return true
        }
        f.ADDITION = "addition";
        f.PRE_REMOVAL = "pre_removal";
        f.REMOVAL = "removal";
        f.BOUNDS = "bounds";
        f.VISIBILITY = "visibility";
        f.GET_RECT_IN_PIXELS = "get_rect_in_pixels";
        function e() {
            var c = this;
            c.b = {}
        }
        e.prototype.c = false;
        e.prototype._dispatchCallback = function(c, i) {
            var g = this;
            if (g.c || !g._hasCallback(c)) {
                return null
            }
            g.c = true;
            try {
                var l = g.b[c](c, i)
            } catch (h) {
            }
            g.c = false;
            return l
        };
        e.prototype._setCallback = function(c, i) {
            if (i) {
                this.b[c] = i
            } else {
                delete this.b[c]
            }
        };
        e.prototype._hasCallback = function(c) {
            return c in this.b && this.b[c]
        };
        function f(c, i) {
            var g = this;
            g.node = c;
            g.rect = 
            new a;
            g.visibility = d(c);
            c.i = "nodeObserverId_" + g.d;
            g.d++;
            g.i = c.i;
            if (i) {
                g.callbacks = i
            } else {
                g.callbacks = new e
            }
            var l = 250;
            g.j = setInterval(function() {
                g.k()
            }, l)
        }
        f.prototype.d = 0;
        f.prototype.k = function() {
            var c = this, i = false, g = c.node.parentNode;
            while (g) {
                if (g == document) {
                    i = true;
                    break
                }
                g = g.parentNode
            }
            if (!i) {
                c.callbacks._dispatchCallback(f.PRE_REMOVAL, c);
                c.callbacks._dispatchCallback(f.REMOVAL, c);
                c.destroy();
                return
            }
            var l = false, h = false;
            if (c.callbacks._hasCallback(f.BOUNDS)) {
                var j = c.rect, m;
                if (c.callbacks._hasCallback(f.GET_RECT_IN_PIXELS)) {
                    m = 
                    c.callbacks._dispatchCallback(f.GET_RECT_IN_PIXELS, c)
                } else {
                    m = b(c.node)
                }
                l = j.left != m.left || j.top != m.top || j.width != m.width || j.height != m.height;
                c.rect = m;
                if (l) {
                    c.callbacks._dispatchCallback(f.BOUNDS, c)
                }
            }
            if (c.callbacks._hasCallback(f.VISIBILITY)) {
                var n = d(c.node), h = c.visibility != n;
                c.visibility = n;
                if (h) {
                    c.callbacks._dispatchCallback(f.VISIBILITY, c)
                }
            }
        };
        f.prototype.destroy = function() {
            var c = this;
            if (c.j != -1) {
                clearInterval(c.j)
            }
            c.callbacks = {}
        };
        google.idlglue.NodeObserver = f;
        google.idlglue.NodeObserverCallbacks = 
        e;
        google.idlglue.Rect = a;
        google.idlglue.getElementRect = b
    })();
    window.google.earth.h = "";
    window.google.earth.setLanguage = function(a) {
        window.google.earth.h = a
    };
    window.google.earth.setErrorUrl = function(a) {
        window.google.earth.f = a
    };
    window.google.earth.setIsSecure = function(a) {
        window.google.earth.e = a
    };
    window.google.earth.setLoadingImageUrl = function(a) {
        window.google.earth.l = a
    };
    window.google.earth.createInstance = function(map3d, initCB, failureCB, e) {
        var f = window.google.earth.ErrorCode, map3dEle;
        initCB = initCB  || function() {};
        failureCB = failureCB || function() {};
        e = e || {};
        if (typeof map3d == "string") {
            map3dEle = document.getElementById(map3d)
        } else {
        map3dEle = map3d
        }
        if (!map3dEle) {
            failureCB(f.ERR_INVALID_DIV);
            return
        }
        e.language = e.language || google.earth.h;
        e.isSecure = google.earth.e;
        e.allowEmptyClientId = true;
        var initCB2 = initCB;
        initCB = function(gearth) {
        var kLayer = gearth.getLayerRoot().getLayerById(gearth.LAYER_BORDERS);
        if (kLayer) {
            google.earth.addEventListener(kLayer, "click", function(s) {
                    s.preventDefault()
                })
            }
            initCB2(gearth)
        };
        var g = "";
        try {
            if (e.language) {
                g = "intl/" + e.language + "/"
            }
        } catch (l) {
        }
        var h = "http://www.google.com/";
        if (window.google.earth.e) {
            h = "https://www.google.com/"
        }
        var j = h + g + "earth/plugin/error.html";
        if ("database" in e && typeof e.database == 
        "string" && window.google.earth.f) {
            j = window.google.earth.f
        }
        var m = window.google.earth.stopIntrospectInstallation_(),
            n = window.google.earth.m(f, initCB, failureCB, m, e),
            o = { skipDownloadButton: e.skipDownloadButton, autoDownload: e.autoDownload };
        window.google.idlglue.create(map3dEle, n, j, o)
    };
    window.google.earth.m = function(a, b, d, e, f) {
    return function(c) {
        if (c) {
            var i = b;
            b = function(l) {
                var h = false;
                google.earth.executeBatch(l, function() {
                    h = true
                });
                if (!h) {
                    var j = "SUCCESS_RECENT_INSTALL_RESTART";
                    window.google.idlglue.showError(c, j, "event bug");
                    d(j);
                    return
                }
                i(l)
            };
            var g = c.iface.getJavascriptInitCode_();
            eval(g)(c, b, d, f);
            if (c.pluginDiv.logStore) {
                c.pluginDiv.logStore.prewarmTime = e.time;
                c.pluginDiv.logStore.prewarmFinished = e.finished;
                c.pluginDiv.logStore.didPrewarm = e.didPrewarm
            }
        } else {
            d(a.ERR_CREATE_PLUGIN)
        }
    }
};
    window.google.earth.a = null;
    window.google.earth.introspectInstallation_ = function() {
        if (window.google.earth.a)
            return;
        var a = document.createElement("div");
        a.style.cssText = "visibility: hidden;position: absolute;width: 0px;height: 0px;";
        document.body.appendChild(a);
        var b = window.google.idlglue.findAvailableId("introspect-installation"), d = window.google.idlglue.getBrowser();
        if (window.google.idlglue.createPluginAsInnerHTML(d, a, b)) {
            if ("getSelf" in a.firstChild) {
                var e = a.firstChild.getSelf();
                if ("introspectInstallation_" in e) {
                    e.introspectInstallation_();
                    window.google.earth.a = a
                }
            }
        }
        if (!window.google.earth.a)
            document.body.removeChild(a)
    };
    if (document.getElementById("__maps-earth-introspect-installation__")) {
        window.google.earth.introspectInstallation_()
    }
    window.google.earth.stopIntrospectInstallation_ = 
    function() {
        var a = {time: -1,finished: false};
        if (window.google.earth.a) {
            var b = window.google.earth.a, d = b.firstChild.getSelf();
            d.stopIntrospectInstallation_();
            a = window.google.earth.queryIntrospectInstallation_();
            document.body.removeChild(b);
            window.google.earth.a = null
        }
        return a
    };
    window.google.earth.queryIntrospectInstallation_ = function() {
        var a = {time: -1,finished: false};
        if (window.google.earth.a) {
            var b = window.google.earth.a, d = b.firstChild.getSelf();
            try {
                a.time = d.getLogValue_(4);
                a.finished = d.getLogValue_(3)
            } catch (e) {
                a.didPrewarm = 
                true
            }
        }
        return a
    };
    window.google.earth.getPluginContainerNode = window.google.idlglue.getPluginContainerNode;
    window.google.earth.isSupported = window.google.idlglue.isSupported;
    window.google.earth.isInstalled = window.google.idlglue.isInstalled;
    window.google.earth.setIsSecure(window.location.protocol == "https:" || typeof window.google.loader == "object" && window.google.loader.Secure);
    if (window.google.earth.e) {
        window.google.earth.setLoadingImageUrl("https://www.google.com/earth/plugin/images/loading.gif")
    } else {
        window.google.earth.setLoadingImageUrl("http://www.google.com/earth/plugin/images/loading.gif")
    }
    if (window.google.earth.LoadArgs) {
        var t = 
        window.google.earth.LoadArgs.split("&");
        for (var r = 0; r < t.length; r++) {
            if (t[r]) {
                var u = t[r].split("=");
                if (u.length == 2 && u[0] == "hl") {
                    window.google.earth.setLanguage(u[1])
                }
            }
        }
    }
    ;
    
    google.loader.loaded({"module": "earth","version": "1.0","components": ["default"]});
    google.loader.eval.earth = function() {
        eval(arguments[0]);
    };
    if (google.loader.eval.scripts && google.loader.eval.scripts['earth']) {
        (function() {
            var scripts = google.loader.eval.scripts['earth'];
            for (var i = 0; i < scripts.length; i++) {
                google.loader.eval.earth(scripts[i]);
            }
        })();
        google.loader.eval.scripts['earth'] = null;
    }
})();
