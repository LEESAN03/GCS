(function() {
    if (!("google" in window)) {
        window.google = {}
    }
    if (!("idlglue" in window.google)) {
        window.google.idlglue = {}
    }
    window.google.idlglue.Ra = true;
    window.google.idlglue.eventHandlersIdToKey = function(a) {
        return "eventHelper_" + a
    };
    window.google.idlglue.EventHelper = function() {
        window.google.idlglue.EventHelper.prototype.A = 0;
        window.google.idlglue.EventHelper.prototype.z = 1;
        this.handlers = [];
        this.handlers[this.A] = {};
        this.handlers[this.z] = {};
        this.F = false;
        this.getHandlerList = function(a, b) {
            var f = b ? this.A : this.z;
            return this.handlers[f][a]
        };
        this.hasHandlers = function(a, b) {
            var f = this.getHandlerList(a, b);
            if (!f) {
                return false
            }
            return f.length > 0
        };
        this.dispatch = function(a, b, f, c) {
            this.F = false;
            var d = this.getHandlerList(a, f);
            if (!d) {
                return
            }
            var g = [];
            for (var e = 0; e < d.length; e++) {
                g.push(d[e])
            }
            for (var e = 0; e < g.length; e++) {
                var i = g[e];
                if (e > 0 && this.F) {
                    var l = false;
                    for (var m = 0; m < d.length; m++) {
                        if (i == d[m]) {
                            l = true;
                            break
                        }
                    }
                    if (!l) {
                        continue
                    }
                }
                try {
                    i.apply(b, c)
                } catch (p) {
                }
            }
            this.F = false
        };
        this.hasHandler = function(a, b, f) {
            var c = this.getHandlerList(a, f);
            if (!c || c.length == 
            0) {
                return false
            }
            for (var d = 0; d < c.length; d++) {
                if (c[d] == b) {
                    return true
                }
            }
            return false
        };
        this.addHandler = function(a, b, f) {
            if (this.hasHandler(a, b, f)) {
                return
            }
            var c = this.getHandlerList(a, f);
            if (!c) {
                c = [];
                var d = f ? this.A : this.z;
                this.handlers[d][a] = c
            }
            c.push(b)
        };
        this.removeHandler = function(a, b, f) {
            var c = this.getHandlerList(a, f);
            if (!c) {
                return
            }
            for (var d = 0; d < c.length; d++) {
                if (c[d] == b) {
                    c.splice(d, 1);
                    this.F = true
                }
            }
        };
        return this
    };
    window.google.idlglue.addEventListener = function(a, b, f, c) {
        var d = window.google.idlglue.eventHandlersIdToKey(a.getEventHandlersId()), 
        g = a.getRootObject().getDiv_().eventHelpers;
        if (g[d] == null) {
            g[d] = new window.google.idlglue.EventHelper
        }
        var e = g[d];
        e.addHandler(b, f, c);
        var i = b.substring(0, 1).toUpperCase() + b.substring(1), l = "on" + i + "EventEnabled";
        a[l](true)
    };
    window.google.idlglue.removeEventListener = function(a, b, f, c) {
        var d = window.google.idlglue.eventHandlersIdToKey(a.getEventHandlersId()), g = a.getRootObject().getDiv_().eventHelpers;
        if (g[d] == null) {
            return
        }
        var e = g[d];
        e.removeHandler(b, f, c);
        var i = b.substring(0, 1).toUpperCase() + b.substring(1), 
        l = "on" + i + "EventEnabled";
        a[l](e.hasHandlers(b, c))
    };
    var G = function(a) {
        a.createCallbackNode = function(d, g, e, i, l) {
            var m = document.createElement("script");
            m.setAttribute("language", "javascript");
            m.setAttribute("for", g);
            m.setAttribute("event", e + "(" + i.join(",") + ")");
            m.setAttribute("text", l);
            if (m.text != l)
                m.text = l;
            d.appendChild(m)
        };
        a.createCallbackBody = function(d, g) {
            var e = "";
            for (var i = 2; i < g.length; i++) {
                e += "argsArray_[" + (i - 2) + "] = " + g[i] + ";"
            }
            var l = "if (object_ == null) { return; }var key_ = window.google.idlglue.eventHandlersIdToKey(    object_.getEventHandlersId());var helper_ = object_.getRootObject().getDiv_().eventHelpers[key_];if (!helper_) { return; }var argsArray_ = [];" + 
            e + "helper_.dispatch('" + d + "', object_, capturePhase_, argsArray_);";
            return l
        };
        var b = document.createElement("div");
        b.id = a.pluginId + "_scriptsNode";
        b.style.display = "none";
        b.innerHTML = "&nbsp;";
        var f = [["eventGEEventEmitterClick", ["object_", "capturePhase_", "event"], "click"], ["eventGEEventEmitterDblclick", ["object_", "capturePhase_", "event"], "dblclick"], ["eventGEEventEmitterMouseover", ["object_", "capturePhase_", "event"], "mouseover"], ["eventGEEventEmitterMousedown", ["object_", "capturePhase_", "event"], "mousedown"], 
            ["eventGEEventEmitterMouseup", ["object_", "capturePhase_", "event"], "mouseup"], ["eventGEEventEmitterMouseout", ["object_", "capturePhase_", "event"], "mouseout"], ["eventGEEventEmitterMousemove", ["object_", "capturePhase_", "event"], "mousemove"], ["eventGETimeControlControlready", ["object_", "capturePhase_"], "controlready"], ["eventGEViewViewchangebegin", ["object_", "capturePhase_"], "viewchangebegin"], ["eventGEViewViewchangeend", ["object_", "capturePhase_"], "viewchangeend"], ["eventGEViewViewchange", ["object_", 
                    "capturePhase_"], "viewchange"], ["eventGEFetchKmlHelper_Load", ["object_", "capturePhase_", "object"], "load"], ["eventGEExecuteBatch_Fire", ["object_", "capturePhase_"], "fire"], ["eventGESideDatabaseHelper_Loggedin", ["object_", "capturePhase_", "object"], "loggedin"], ["eventGESideDatabaseHelper_Loginfail", ["object_", "capturePhase_"], "loginfail"], ["eventGETimeHistoricalimageryready", ["object_", "capturePhase_"], "historicalimageryready"], ["eventGEPluginFrameend", ["object_", "capturePhase_"], "frameend"], ["eventGEPluginDefaultfeatureclick_", 
                ["object_", "capturePhase_", "feature", "x", "y", "button"], "defaultfeatureclick_"], ["eventGEPluginEarthready_", ["object_", "capturePhase_"], "earthready_"], ["eventGEPluginRenderready_", ["object_", "capturePhase_"], "renderready_"], ["eventGEPluginKmlchange_", ["object_", "capturePhase_"], "kmlchange_"], ["eventGEPluginBalloonclose", ["object_", "capturePhase_"], "balloonclose"], ["eventGEPluginTermsofusemoved_", ["object_", "capturePhase_"], "termsofusemoved_"], ["eventGEPluginBalloonmoved_", ["object_", "capturePhase_"], 
                "balloonmoved_"], ["eventGEPluginBalloonchangenotify_", ["object_", "capturePhase_", "activeBalloon"], "balloonchangenotify_"], ["eventGEPluginBalloonopening", ["object_", "capturePhase_", "event"], "balloonopening"], ["eventGEPluginBalloonopened_", ["object_", "capturePhase_"], "balloonopened_"]];
        for (var c = 0; c < f.length; c++) {
            a.createCallbackNode(b, a.eventNodeId, f[c][0], f[c][1], a.createCallbackBody(f[c][2], f[c][1]))
        }
        a.div.appendChild(b);
        b.innerHTML += "&nbsp;";
        a.iface.castObject = function(d, g) {
            var e = d.castObject__(g[0], 
            g[1], g[2], g[3], g[4], g[5], g[6], g[7], g[8], g[9], g[10], g[11]);
            return e
        }
    }, H = function(a) {
        function b(g) {
            this.QueryInterface = function(e) {
                if (e.equals(Components.interfaces.IGEPlugin_Events)) {
                    return this
                } else {
                    throw Components.results.NS_NOINTERFACE;
                }
            };
            this.addHandler = function(e, i) {
                this[e] = function() {
                    var l = "google" in window && "idlglue" in window.google && window.google.idlglue.Ra;
                    if (!l) {
                        return
                    }
                    var m = arguments[0];
                    if (m == null) {
                        return
                    }
                    var p = arguments[1], k = window.google.idlglue.eventHandlersIdToKey(m.getEventHandlersId()), 
                    q = g.eventHelpers[k];
                    if (!q) {
                        return
                    }
                    var r = [];
                    for (var u = 2; u < arguments.length; u++) {
                        r[u - 2] = arguments[u]
                    }
                    q.dispatch(i, m, p, r)
                }
            };
            return this
        }
        var f = new b(a.div), c = [["eventGEEventEmitterClick", "click"], ["eventGEEventEmitterDblclick", "dblclick"], ["eventGEEventEmitterMouseover", "mouseover"], ["eventGEEventEmitterMousedown", "mousedown"], ["eventGEEventEmitterMouseup", "mouseup"], ["eventGEEventEmitterMouseout", "mouseout"], ["eventGEEventEmitterMousemove", "mousemove"], ["eventGETimeControlControlready", "controlready"], 
            ["eventGEViewViewchangebegin", "viewchangebegin"], ["eventGEViewViewchangeend", "viewchangeend"], ["eventGEViewViewchange", "viewchange"], ["eventGEFetchKmlHelper_Load", "load"], ["eventGEExecuteBatch_Fire", "fire"], ["eventGESideDatabaseHelper_Loggedin", "loggedin"], ["eventGESideDatabaseHelper_Loginfail", "loginfail"], ["eventGETimeHistoricalimageryready", "historicalimageryready"], ["eventGEPluginFrameend", "frameend"], ["eventGEPluginDefaultfeatureclick_", "defaultfeatureclick_"], ["eventGEPluginEarthready_", "earthready_"], 
            ["eventGEPluginRenderready_", "renderready_"], ["eventGEPluginKmlchange_", "kmlchange_"], ["eventGEPluginBalloonclose", "balloonclose"], ["eventGEPluginTermsofusemoved_", "termsofusemoved_"], ["eventGEPluginBalloonmoved_", "balloonmoved_"], ["eventGEPluginBalloonchangenotify_", "balloonchangenotify_"], ["eventGEPluginBalloonopening", "balloonopening"], ["eventGEPluginBalloonopened_", "balloonopened_"]];
        for (var d = 0; d < c.length; d++) {
            f.addHandler(c[d][0], c[d][1])
        }
        a.iface.setEventsProxy_(f);
        a.iface.castObject = function(g, 
        e) {
            return g.QueryInterface(e)
        }
    }, F = function(a) {
        var b = function() {
            var f = window.google.idlglue;
            try {
                var c = a.iface;
                if (c) {
                    var d = -1;
                    do {
                        d = c.getNextPendingDeleteEventHandler_();
                        if (d > 0) {
                            var g = f.eventHandlersIdToKey(d);
                            delete a.div.eventHelpers[g]
                        }
                    } while (d > 0)
                }
            } catch (e) {
                window.clearInterval(a.ib);
                a.div.eventHelpers = null
            }
        };
        return b
    };
    window.google.idlglue.notifyInitCodeUnloaded = function() {
        window.google.idlglue.Ra = false
    };
    window.google.idlglue.init = function(a) {
        var b = window.google.idlglue, f = false;
        if (a.iface && a.iface.isInProcess_()) {
            f = 
            true;
            a.div = {}
        }
        a.div.eventHelpers = {};
        var c = F(a), d = 3000;
        if (f) {
            d = 300000
        }
        a.ib = window.setInterval(c, 3000);
        if (f || b.supportsNpapi(a.browser)) {
            H(a)
        } else if (a.browser == b.BROWSER_IE) {
            G(a)
        } else {
            b.showError(a, "ERR_UNSUPPORTED_BROWSER", "");
            return false
        }
        a.iface = a.iface.getSelf();
        a.iface.setDiv_(a.div);
        return true
    };
    if (!("google" in window)) {
        window.google = {}
    }
    if (!("earth" in window.google)) {
        window.google.earth = {}
    }
    ;
    google.earth.BalloonManager2 = function(a, b, f, c) {
        var d = this;
        d.Ba = document.getElementById("debug_div");
        d.a = a.iface;
        google.idlglue.addEventListener(d.a, "balloonmoved_", function() {
            d.g("EVENT: balloonmoved");
            d.m(google.earth.BalloonManager2.e.Moved)
        }, false);
        google.idlglue.addEventListener(d.a, "balloonclose", function() {
            d.g("EVENT: balloonclose");
            d.m(google.earth.BalloonManager2.e.Close)
        }, false);
        google.idlglue.addEventListener(d.a, "balloonchangenotify_", function() {
            d.g("EVENT: balloonchangenotify");
            var g = 
            d.a.getBalloon();
            if (g) {
                d.m(google.earth.BalloonManager2.e.ContentChanged)
            } else {
                if (d.balloonState != google.earth.BalloonManager2.c.Closed) {
                    d.m(google.earth.BalloonManager2.e.Close)
                }
            }
        }, false);
        google.idlglue.addEventListener(d.a, "defaultfeatureclick_", function() {
            d.g("EVENT: defaultfeatureclick");
            d.Ea.apply(d, arguments)
        }, false);
        d.balloonState = google.earth.BalloonManager2.c.Closed;
        d.j = b;
        d.k = d.j.ownerDocument;
        d.b = null;
        d.f = null;
        d.h = null;
        d.i = null;
        d.balloonEvents = [];
        d.ya = 0;
        d.xa = 0;
        d.Aa = 0;
        d.za = 0;
        d.W = 0;
        d.V = 0;
        d.U = 0;
        d.T = 0;
        d.lb = 0;
        d.kb = 0;
        d.K = null;
        d.ob = 250;
        d.ka = null;
        d.nb = function() {
            d.ka = null;
            d.ab()
        };
        d.d = null;
        d.da = a.iframeShimSimulator;
        d.u = -1;
        d.X = null;
        google.idlglue.addErrorCleanupCallback(a, function() {
            d.p()
        });
        d.wb = function(g) {
            d.g("sizeWatchListenerCloser called");
            d.xb(g)
        };
        d.ba = true;
        if (google.idlglue.getBrowser() == google.idlglue.BROWSER_FIREFOX && google.idlglue.getPlatform() == google.idlglue.PLATFORM_WINDOWS) {
            if (navigator.userAgent.match("Firefox/3.5.[0-9]")) {
                d.ba = false
            }
        }
        d.language = f || "en";
        d.jb = c
    };
    google.earth.BalloonManager2.c = 
    {Closed: 1,Opening: 2,ResizeHorizontal: 3,ReflowHorizontal: 4,ResizeVertical: 5,ReflowVertical: 6,Opened: 7,Closing: 8,WaitingResize: 9,Invalid: 10};
    google.earth.BalloonManager2.e = {Open: 1,Moved: 2,Close: 3,ContentChanged: 4};
    google.earth.BalloonManager2.prototype.init = function() {
        var a = this;
        a.b = a.k.createElement("div");
        a.b.style.cssText = "display: none;z-index: 100; position: absolute;";
        a.j.appendChild(a.b);
        a.f = a.k.createElement("div");
        a.f.style.cssText = "margin: 0px; padding: 0px; position: relative; left: 0px; top: 0px;";
        a.b.appendChild(a.f);
        a.h = a.k.createElement("div");
        a.h.style.cssText = "margin: 0px; padding: 0px; position: absolute; top: 0px; left: 0px; overflow: auto";
        a.f.appendChild(a.h);
        if (google.idlglue.getPlatform() == google.idlglue.PLATFORM_WINDOWS) {
            a.d = a.k.createElement("iframe");
            a.d.name = "iframeshim";
            a.d.style.position = "absolute";
            a.d.style.left = "0px";
            a.d.style.top = "0px";
            a.d.style.width = "100%";
            a.d.style.height = "100%";
            a.d.style.filter = "progid:DXImageTransform.Microsoft.Alpha(opacity=0)";
            a.d.style.zIndex = -10000;
            a.d.setAttribute("frameborder", "0");
            a.d.setAttribute("scrolling", "no");
            a.d.setAttribute("src", "javascript:void(0);");
            if (google.idlglue.getBrowser() == google.idlglue.BROWSER_FIREFOX && !navigator.userAgent.match("Firefox/3.0")) {
                a.d.style.display = "none"
            }
            a.b.appendChild(a.d)
        } else {
            a.u = a.a.createCutout_()
        }
        if (a.h.addEventListener) {
            a.attachListener = function(b, f, c) {
                b.addEventListener(f, c, false)
            };
            a.detachListener = function(b, f, c) {
                b.removeEventListener(f, c, false)
            }
        } else {
            a.attachListener = function(b, f, c) {
                b.attachEvent("on" + 
                f, c)
            };
            a.detachListener = function(b, f, c) {
                b.detachEvent("on" + f, c)
            }
        }
    };
    google.earth.BalloonManager2.prototype.g = function(a) {
        var b = this;
        if (!b.Ba) {
            return
        }
        b.Ba.innerHTML += a + "<br>\n"
    };
    google.earth.BalloonManager2.prototype.J = function() {
        var a = this;
        if (!a.K) {
            a.K = window.setTimeout(function() {
                a.B()
            }, 0)
        }
    };
    google.earth.BalloonManager2.prototype.Qa = function(a) {
        var b = this, f = true;
        for (var c = 0; c < b.balloonEvents.length; ++c) {
            if (b.balloonEvents[c] == a) {
                f = false;
                break
            }
        }
        if (f)
            b.balloonEvents.push(a)
    };
    google.earth.BalloonManager2.prototype.m = 
    function(a) {
        var b = this;
        switch (a) {
            case google.earth.BalloonManager2.e.ContentChanged:
            case google.earth.BalloonManager2.e.Moved:
                b.Qa(a);
                break;
            case google.earth.BalloonManager2.e.Open:
            case google.earth.BalloonManager2.e.Close:
                b.balloonEvents = [];
                b.balloonEvents.push(a);
                break
        }
        if (google.earth.BalloonManager2.e.ContentChanged) {
            b.J()
        } else {
            b.B()
        }
    };
    google.earth.BalloonManager2.prototype.wa = function() {
        var a = this;
        return a.balloonEvents.length > 0 && a.balloonEvents[0] == google.earth.BalloonManager2.e.Close
    };
    google.earth.BalloonManager2.prototype.B = 
    function() {
        var a = this, b = google.earth.BalloonManager2.c.Invalid;
        window.clearTimeout(a.K);
        a.K = null;
        if (a.wa()) {
            a.g("EVENT: close event at front of queue");
            a.balloonEvents.shift();
            a.balloonState = a.aa();
            if (a.balloonState == google.earth.BalloonManager2.c.Closed) {
                a.g("EVENT: closing balloon.");
                a.closeBalloon_()
            }
            a.updateCutout_();
            a.J();
            return
        }
        if (!a.a.getBalloon() && a.balloonState != google.earth.BalloonManager2.c.Closed) {
            a.balloonState = google.earth.BalloonManager2.c.Closing;
            a.balloonEvents = []
        }
        switch (a.balloonState) {
            case google.earth.BalloonManager2.c.Closed:
                b = 
                a.aa();
                break;
            case google.earth.BalloonManager2.c.Opening:
                b = a.Ja();
                break;
            case google.earth.BalloonManager2.c.ResizeHorizontal:
                b = a.Ma();
                break;
            case google.earth.BalloonManager2.c.ReflowHorizontal:
                b = a.Ka();
                break;
            case google.earth.BalloonManager2.c.ResizeVertical:
                b = a.Na();
                break;
            case google.earth.BalloonManager2.c.ReflowVertical:
                b = a.La();
                break;
            case google.earth.BalloonManager2.c.Opened:
                b = a.Ia();
                break;
            case google.earth.BalloonManager2.c.WaitingResize:
                b = a.Oa();
                break;
            case google.earth.BalloonManager2.c.Closing:
                b = 
                a.Ha();
                break;
            default:
                a.g("illegal state reached in state machine.");
                break
        }
        a.updateCutout_();
        if (b != a.balloonState) {
            a.balloonState = b;
            if (a.balloonState == google.earth.BalloonManager2.c.ReflowVertical && (google.idlglue.getBrowser() == google.idlglue.BROWSER_IE || google.idlglue.getBrowser() == google.idlglue.BROWSER_CHROME)) {
                a.J()
            } else {
                a.B()
            }
        }
    };
    google.earth.BalloonManager2.prototype.updateCutout_ = function() {
        var a = this;
        if (a.u >= 0) {
            var b = a.da.Z(a.b);
            a.a.updateCutout_(a.u, b.left, b.top, b.width, b.height)
        }
    };
    google.earth.BalloonManager2.prototype.deleteCutout_ = 
    function() {
        var a = this;
        if (a.u >= 0)
            a.a.deleteCutout_(a.u)
    };
    google.earth.BalloonManager2.prototype.I = function() {
        var a = this;
        if (a.i && a.i.parentNode == a.f)
            a.f.removeChild(a.i);
        a.i = null
    };
    google.earth.BalloonManager2.prototype.Za = function() {
        var a = this, b = a.a.getBalloon();
        if (!b)
            return false;
        a.h.style.display = "";
        if (b.getType() == "GEHtmlDivBalloon") {
            var f = b.getContentDiv();
            if (!f || a.i && a.i != f.parentNode)
                a.I()
        } else {
            a.I()
        }
        if (b.getType() == "GEFeatureBalloon") {
            var c = b.getFeature();
            if (!c) {
                return false
            }
            a.h.style.fontSize = 
            "small";
            a.h.innerHTML = c.getBalloonText_() + " ";
            a.n = "#FFFFFF";
            a.r = "#000000";
            var d = c.getBalloonKmlStyle_();
            if (d) {
                if (d.getType() == "KmlStyleMap") {
                    d = d.getNormalStyle()
                }
                var g = d.getBalloonStyle();
                if (g) {
                    a.n = "#" + a.ea(g.getBgColor());
                    a.r = "#" + a.ea(g.getTextColor())
                }
            }
        } else {
            a.h.style.fontSize = "";
            if (b.getType() == "GEHtmlDivBalloon") {
                a.h.style.display = "none";
                a.h.innerHTML = "";
                var f = b.getContentDiv();
                if (f) {
                    if (f.parentNode == null || f.parentNode && f.parentNode.parentNode != a.f) {
                        a.i = document.createElement("div");
                        a.i.appendChild(f);
                        a.i.style.position = "absolute";
                        a.i.style.overflow = "auto";
                        a.i.style.left = "0px";
                        a.i.style.top = "0px";
                        a.f.appendChild(a.i)
                    }
                }
            }
            if (b.getType() == "GEHtmlStringBalloon") {
                a.h.innerHTML = b.getContentString() + " "
            }
            a.n = a.pa(b.getBackgroundColor(), "#FFFFFF");
            a.r = a.pa(b.getForegroundColor(), "#000000")
        }
        a.b.style.backgroundColor = a.n;
        a.b.style.color = a.r;
        return true
    };
    google.earth.BalloonManager2.prototype.aa = function() {
        var a = this;
        while (a.balloonEvents.length > 0) {
            var b = a.balloonEvents.shift();
            if (b != google.earth.BalloonManager2.e.Close)
                return google.earth.BalloonManager2.c.Opening
        }
        return google.earth.BalloonManager2.c.Closed
    };
    google.earth.BalloonManager2.prototype.Ja = function() {
        var a = this, b = a.a.getBalloon();
        if (!b)
            return google.earth.BalloonManager2.c.Closed;
        if (a.a.getFeatureBalloonShowContentNatively_() && b.getType() == "GEFeatureBalloon")
            return google.earth.BalloonManager2.c.Opened;
        if (!a.Za()) {
            if (a.a.getBalloon())
                return google.earth.BalloonManager2.c.Opened
        }
        return google.earth.BalloonManager2.c.ResizeHorizontal
    };
    google.earth.BalloonManager2.prototype.Ma = function() {
        var a = this;
        a.Ta();
        return google.earth.BalloonManager2.c.ReflowHorizontal
    };
    google.earth.BalloonManager2.prototype.Ka = function() {
        var a = this, b = a.s(), f = b.scrollWidth, c = f;
        c = Math.min(c, a.ya);
        c = Math.max(c, a.Aa);
        a.f.style.width = c + "px";
        b.style.width = c + "px";
        if (f <= c && a.ba) {
            b.style.overflowX = "hidden"
        } else {
            b.style.overflowX = "auto"
        }
        return google.earth.BalloonManager2.c.ResizeVertical
    };
    google.earth.BalloonManager2.prototype.Na = function() {
        var a = this, b = a.s(), f = b.scrollHeight, c = f;
        c = Math.min(c, a.xa);
        c = Math.max(c, a.za);
        a.f.style.height = c + "px";
        b.style.height = c + "px";
        if (f <= c && a.ba) {
            b.style.overflowY = 
            "hidden"
        } else {
            b.style.overflowY = "auto"
        }
        return google.earth.BalloonManager2.c.ReflowVertical
    };
    google.earth.BalloonManager2.prototype.La = function() {
        var a = this, b = a.f.clientWidth, f = a.f.clientHeight, c = a.l(), d = a.a.getBalloon(), g = a.s();
        if (b == 0 && g) {
            if (d.getType() == "GEHtmlDivBalloon" && g.firstChild) {
                b = g.firstChild.clientWidth
            } else {
                b = g.clientWidth
            }
        }
        var e = Math.ceil(b * c), i = Math.ceil(f * c);
        a.lb = e;
        a.kb = i;
        if (a.d != null) {
            a.d.style.width = b + "px";
            a.d.style.height = f + "px"
        }
        a.f.style.width = b + "px";
        a.f.style.height = f + "px";
        g.style.width = 
        b + "px";
        g.style.height = f + "px";
        a.h.style.position = "";
        var l = d.getFeature();
        if (d.getType() == "GEFeatureBalloon") {
            var m = l.getComputedStyle().getBalloonStyle(), p = m.getTextColor(), k = m.getBgColor(), q = p.getR() << 16 | p.getG() << 8 | p.getB(), r = k.getR() << 16 | k.getG() << 8 | k.getB();
            a.a.showGenericBalloon_(l, q, r, e, i, d.getCloseButtonEnabled())
        } else {
            var r = parseInt(a.n.substring(1, 7), 16), q = parseInt(a.r.substring(1, 7), 16);
            a.a.showGenericBalloon_(l, q, r, e, i, d.getCloseButtonEnabled())
        }
        a.U = g.scrollWidth;
        a.T = g.scrollHeight;
        return google.earth.BalloonManager2.c.WaitingResize
    };
    google.earth.BalloonManager2.prototype.$ = function() {
        var a = this, b = a.s(), f = a.l(), c = a.a.getBalloonState_(), d = c.getBalloonLeft(), g = c.getBalloonTop(), e = c.getBalloonRight(), i = c.getBalloonBottom(), l = e - d, m = i - g, p = l / f, k = m / f, q = d / f, r = g / f;
        a.b.style.left = q + "px";
        a.b.style.top = r + "px";
        if (a.d != null) {
            a.d.style.width = p + "px";
            a.d.style.height = k + "px"
        }
        a.f.style.width = p + "px";
        a.f.style.height = k + "px";
        b.style.width = p + "px";
        b.style.height = k + "px"
    };
    google.earth.BalloonManager2.prototype.Oa = function() {
        var a = this;
        if (a.balloonEvents.length == 
        0)
            return google.earth.BalloonManager2.c.WaitingResize;
        while (a.balloonEvents.length > 0) {
            var b = a.balloonEvents.shift();
            if (b == google.earth.BalloonManager2.e.Moved) {
                a.$();
                return google.earth.BalloonManager2.c.Opened
            }
            if (b == google.earth.BalloonManager2.e.Close) {
                a.closeBalloon_();
                return google.earth.BalloonManager2.c.Closed
            }
            if (b == google.earth.BalloonManager2.e.Open) {
                a.g("should not get here")
            }
            if (b == google.earth.BalloonManager2.e.ContentChanged) {
                return google.earth.BalloonManager2.c.Opening
            }
        }
        return google.earth.BalloonManager2.c.WaitingResize
    };
    google.earth.BalloonManager2.prototype.Ia = function() {
        var a = this, b = google.earth.BalloonManager2.c.Opened;
        while (a.balloonEvents.length > 0) {
            var f = a.balloonEvents.shift();
            switch (f) {
                case google.earth.BalloonManager2.e.Close:
                    b = google.earth.BalloonManager2.c.Closing;
                    break;
                case google.earth.BalloonManager2.e.Open:
                    a.g("Received an open event while the balloon was open!");
                    break;
                case google.earth.BalloonManager2.e.Moved:
                    a.$();
                    break;
                case google.earth.BalloonManager2.e.ContentChanged:
                    b = google.earth.BalloonManager2.c.Opening;
                    break;
                default:
                    a.g("invalid event in event queue");
                    break
            }
        }
        if (b == google.earth.BalloonManager2.c.Opened)
            a.ia();
        return b
    };
    google.earth.BalloonManager2.prototype.Ha = function() {
        var a = this;
        a.h.innerHTML = "";
        a.closeBalloon_();
        return google.earth.BalloonManager2.c.Closed
    };
    google.earth.BalloonManager2.prototype.va = function() {
        var a = this;
        a.b.style.display = "none";
        a.b.style.left = -screen.width * 2 + "px";
        a.b.style.top = -screen.height * 2 + "px";
        a.f.style.width = "10px";
        a.f.style.height = "10px";
        a.a.setBalloon(null);
        a.I()
    };
    google.earth.BalloonManager2.prototype.closeBalloon_ = 
    function() {
        var a = this;
        a.g("EVENT: closeballoon");
        a.va();
        a.a.closeBalloon_()
    };
    google.earth.BalloonManager2.prototype.Ta = function() {
        var a = this, b = a.l();
        a.W = a.a.getWindowWidth_();
        a.V = a.a.getWindowHeight_();
        var f = a.W - 100, c = a.V - 70;
        f = f / b;
        c = c / b;
        var d = a.a.getBalloon(), g = d.getMaxWidth() / b, e = d.getMaxHeight() / b, i = 0, l = 0;
        if (d.getMinWidth() > 0) {
            i = Math.max(90, d.getMinWidth() / b);
            i = Math.min(i, f)
        }
        if (d.getMinHeight() > 0) {
            l = Math.max(60, d.getMinHeight() / b);
            l = Math.min(l, c)
        }
        e = e <= 0 ? c : e;
        g = g <= 0 ? f : g;
        e = Math.max(e, l);
        g = Math.max(g, 
        i);
        if (g <= 0)
            g = f;
        if (e <= 0)
            e = c;
        if (g < f)
            f = g;
        if (e < c)
            c = e;
        f = Math.max(f, 0);
        c = Math.max(c, 0);
        a.ya = f;
        a.xa = c;
        a.Aa = i;
        a.za = l;
        a.b.style.display = "none";
        a.b.style.left = -screen.width * 2 + "px";
        a.b.style.top = -screen.height * 2 + "px";
        a.f.style.width = f + "px";
        a.f.style.height = c + "px";
        a.h.style.position = "absolute";
        a.h.style.width = "";
        a.h.style.height = "";
        a.b.style.display = ""
    };
    google.earth.BalloonManager2.prototype.n = "";
    google.earth.BalloonManager2.prototype.r = "";
    google.earth.BalloonManager2.prototype.p = function() {
        var a = this;
        a.deleteCutout_();
        if (a.da)
            a.da.Fa();
        a.b.style.display = "none";
        try {
            a.j.removeChild(a.b)
        } catch (b) {
        }
        a.b = null
    };
    google.earth.BalloonManager2.prototype.l = function() {
        var a = this, b = a.j.clientWidth;
        if (b > 0 && a.a.getWindowWidth_() > 0) {
            return a.a.getWindowWidth_() / b
        } else {
            return 1
        }
    };
    google.earth.BalloonManager2.prototype.Ca = function(a, b, f, c) {
        var d = this;
        if (c != 0) {
            return
        }
        var g = a.getGeometry().getDescriptionId();
        if (g == "") {
            return
        }
        var e = document.createElement("div");
        e.style.width = "485px";
        e.style.height = "280px";
        var i = {};
        i.ui = "3dmfe";
        i.mid = 
        g;
        i.hl = d.language;
        var l = [];
        for (var m in i) {
            l.push(encodeURIComponent(m) + "=" + encodeURIComponent(i[m]).replace(/%3A/gi, ":").replace(/%20/g, "+").replace(/%2C/gi, ",").replace(/%7C/gi, "|"))
        }
        var p = "http://sketchup.google.com/3dwarehouse/earthbubble";
        if (d.jb) {
            p = "https://sketchup.google.com/3dwarehouse/earthbubble"
        }
        var k = p + "?" + l.join("&"), q = document.createElement("iframe");
        q.setAttribute("frameborder", "0");
        q.style.width = "100%";
        q.style.height = "100%";
        q.setAttribute("src", k);
        e.appendChild(q);
        var r = d.a.createHtmlDivBalloon("");
        r.setContentDiv(e);
        r.setFeature(a);
        r.setCloseButtonEnabled(true);
        d.a.setBalloon(r)
    };
    google.earth.BalloonManager2.prototype.Da = function(a, b, f, c) {
        var d = this;
        if (a == d.a.getBalloon())
            return;
        if (c == 0 && a != null && a.getBalloonText_() != d.X) {
            var g = d.a.createFeatureBalloon("");
            g.setFeature(a);
            d.a.setBalloon(g)
        }
    };
    google.earth.BalloonManager2.prototype.Ea = function(a, b, f, c) {
        var d = this;
        d.g("defaultFeatureClickHandler_ called");
        if (d.X == null) {
            d.X = d.a.createPlacemark("").getBalloonText_()
        }
        if (a.getType() == "KmlPlacemark" && 
        a.getGeometry() != null && a.getGeometry().getType() == "GEBuilding") {
            d.Ca(a, b, f, c)
        } else {
            d.Da(a, b, f, c)
        }
    };
    google.earth.BalloonManager2.prototype.ea = function(a) {
        if (a) {
            var b = a.get();
            return b.substring(6, 8) + b.substring(4, 6) + b.substring(2, 4)
        } else {
            return ""
        }
    };
    google.earth.BalloonManager2.prototype.pa = function(a, b) {
        if (a && typeof a == "string" && a.length == 7 && a.substr(0, 1) == "#") {
            return a
        } else {
            return b
        }
    };
    google.earth.BalloonManager2.prototype.ia = function() {
        var a = this;
        if (a.ka)
            return;
        a.ka = window.setTimeout(a.nb, a.ob)
    };
    google.earth.BalloonManager2.prototype.ab = function() {
        var a = this, b = null;
        try {
            b = a.a.getBalloon()
        } catch (f) {
        }
        if (!b)
            return;
        if (a.balloonState != google.earth.BalloonManager2.c.Opened)
            return;
        var c = a.s(), d = c.scrollWidth, g = c.scrollHeight, e = Math.abs(d - a.U), i = Math.abs(g - a.T);
        if (e > 1 || i > 1 || a.W != a.a.getWindowWidth_() || a.V != a.a.getWindowHeight_()) {
            a.g("sw: " + d + " sh: " + g + " saveSW: " + a.U + " saveSH: " + a.T);
            a.m(google.earth.BalloonManager2.e.ContentChanged)
        } else {
            a.ia()
        }
    };
    google.earth.BalloonManager2.prototype.s = function() {
        return this.i != 
        null ? this.i : this.h
    };
    google.earth.ClientIdCheck = function(a, b, f, c) {
        var d = this;
        d.ga = "http://maps.google.com";
        if (f) {
            d.ga = "https://maps-api-ssl.google.com/"
        }
        d.ga += "/maps/api/earth_api/AuthenticationService.Authenticate";
        d.D = "";
        d.S = "";
        d.mb = "";
        d.w = null;
        d.vb = 0;
        d.Sa = false;
        d.H = false;
        d.v = a;
        d.eb = 5000;
        if (b && typeof b == "number" && b > 0)
            d.eb = b;
        d.hb = c
    };
    google.earth.ClientIdCheck.prototype.ua = function() {
        var a = this, b = a.ta(google.earth.LoadArgs);
        if (!a.hb && !a.D) {
            a.v();
            return
        }
        a.processing = true;
        a.sa()
    };
    google.earth.ClientIdCheck.prototype.ta = 
    function(a) {
        var b = this;
        if (!a)
            return;
        var f = a.split("&"), c;
        for (c = 0; c < f.length; ++c) {
            var d = f[c].split("=");
            if (d.length != 2)
                continue;
            var g = d[0], e = d[1];
            switch (g) {
                case "client":
                    b.D = e;
                    break;
                case "channel":
                    b.S = e;
                    break;
                case "sensor":
                    if (e == "true" || e == "false")
                        b.mb = e;
                    break;
                default:
                    break
            }
        }
    };
    google.earth.ClientIdCheck.prototype.sa = function() {
        var a = this;
        if (!("jsonCallbacks" in google.earth)) {
            google.earth.jsonCallbacks = {};
            google.earth.jsonIndex = 0
        }
        var b = "f" + google.earth.jsonIndex++;
        google.earth.jsonCallbacks[b] = function(g) {
            if (a.w) {
                window.clearTimeout(a.w);
                a.w = 0
            }
            delete google.earth.jsonCallbacks[b];
            a.H = false;
            if (g && "authenticated" in g && g.authenticated) {
                a.Sa = true;
                return
            }
            if (a.v) {
                a.v()
            }
        };
        var f = document.getElementsByTagName("head")[0];
        if (!f) {
            a.H = false;
            return
        }
        var c = document.createElement("script");
        a.w = window.setTimeout(function() {
            a.H = false;
            a.Sa = false;
            if (a.v) {
                a.v()
            }
            a.w = 0
        }, a.eb);
        var d = a.ga + "?url=" + encodeURIComponent(window.location);
        if (a.D) {
            d += "&client_id=" + encodeURIComponent(a.D)
        }
        if (a.S) {
            d = d + "&client_channel=" + encodeURIComponent(a.S)
        }
        d = d + "&callback=google.earth.jsonCallbacks." + 
        b;
        c.setAttribute("type", "text/javascript");
        c.setAttribute("charset", "UTF-8");
        c.setAttribute("src", d);
        f.appendChild(c);
        a.H = true
    };
    window.google.earth.fetchKml = function(a, b, f) {
        var c = a.createFetchKmlHelper_();
        window.google.earth.addEventListener(c, "load", f);
        a.fetchKmlUsingHelper_(b, c)
    };
    window.google.earth.executeBatch = function(a, b) {
        var f = a.createBatchExecutor_();
        window.google.earth.addEventListener(f, "fire", b);
        a.executeBatch_(f)
    };
    window.google.earth.addSideDatabase = function(a, b, f, c, d) {
        var g = function(p, k, q, r) {
            if (!p || typeof p != "object")
                return r;
            if (k in p && typeof p[k] == q)
                return p[k];
            return r
        };
        if (!b || typeof b != "string")
            throw google.earth.ErrorCode.ERR_BAD_URL;
        var e = g(d, "userName", "string", ""), i = g(d, "password", "string", ""), l = a.createSideDatabaseHelper_(), m = function(p) {
            window.setTimeout(function() {
                f(p)
            }, 0)
        };
        window.google.earth.addEventListener(l, "loggedin", m);
        window.google.earth.addEventListener(l, "loginfail", c);
        a.addSideDatabase_(b, 
        e, i, l)
    };
    (function() {
        var a = google.idlglue.NodeObserver;
        function b(f, c, d) {
            if (!(c.addEventListener && (document.implementation.hasFeature("MutationEvents", "2.0") || window.MutationEvent))) {
                return null
            }
            var g = this;
            f = f.toLowerCase();
            g.Ya = c;
            g.bb = f;
            if (d) {
                g.o = d
            } else {
                g.o = new google.idlglue.NodeObserverCallbacks
            }
            g.$a();
            g.Ua = function(e) {
                return g.Va(e)
            };
            c.addEventListener("DOMNodeInserted", g.Ua, false);
            g.G = {};
            g.P(g.Ya)
        }
        b.prototype.$a = function() {
            var f = this, c = function(d, g) {
                if (d == a.PRE_REMOVAL) {
                    f.Xa(g.node)
                }
            };
            f.o._setCallback(a.PRE_REMOVAL, 
            c)
        };
        b.prototype.Va = function(f) {
            var c = this, d = f.target;
            if (f.type == "DOMNodeInserted" && d) {
                c.P(d)
            }
        };
        b.prototype.P = function(f) {
            var c = this;
            if (f.tagName && f.tagName.toLowerCase() == c.bb) {
                c.Q(f)
            }
            if (f.getElementsByTagName) {
                var d = f.getElementsByTagName(c.bb);
                for (var g = 0; g < d.length; g++) {
                    c.Q(d[g])
                }
            }
        };
        b.prototype.Y = function(f) {
            try {
                if (this.G[f.la]) {
                    return f.la
                }
            } catch (c) {
                return undefined
            }
        };
        b.prototype.ca = 0;
        b.prototype.Q = function(f) {
            var c = this, d = c.Y(f);
            if (!d) {
                var g = new google.idlglue.NodeObserver(f, c.o);
                f.la = c.ca;
                c.ca++;
                c.G[f.la] = g;
                c.o._dispatchCallback(a.ADDITION, g)
            }
        };
        b.prototype.Xa = function(f) {
            var c = this, d = c.Y(f);
            if (d) {
                delete c.G[d]
            }
        };
        b.prototype._setCallback = function(f, c) {
            return this.o._setCallback(f, c)
        };
        b.prototype.destroy = function() {
            var f = this;
            try {
                f.Ya.removeEventListener("DOMNodeInserted", f.Ua)
            } catch (c) {
            }
            delete f.G;
            delete f.o
        };
        google.idlglue.TagObserver = b
    })();
    google.earth.IframeShimSimulator = function(a) {
        if (a.platform != google.idlglue.PLATFORM_MAC) {
            return
        }
        var b = this, f = google.idlglue;
        b.a = a.iface;
        b.Wa = a.positioningDiv;
        b.ub = b.a.getWindow();
        var c = function(e, i) {
            if (i._cutout_id >= 0 && i.visibility) {
                return b.Z(i.node)
            } else {
                return new f.Rect(0, 0, 0, 0)
            }
        }, d = function(e, i) {
            try {
                b.a.getWindowWidth_()
            } catch (l) {
                return
            }
            if (e == f.NodeObserver.REMOVAL) {
                b.a.deleteCutout_(i._cutout_id);
                i._cutout_id = -1;
                return
            }
            if (e == f.NodeObserver.ADDITION) {
                i._cutout_id = b.a.createCutout_()
            }
            if (i._cutout_id >= 
            0) {
                var m = i.rect;
                b.a.updateCutout_(i._cutout_id, m.left, m.top, m.width, m.height)
            }
        }, g = new google.idlglue.NodeObserverCallbacks;
        g._setCallback(google.idlglue.NodeObserver.ADDITION, d);
        g._setCallback(google.idlglue.NodeObserver.BOUNDS, d);
        g._setCallback(google.idlglue.NodeObserver.REMOVAL, d);
        g._setCallback(google.idlglue.NodeObserver.VISIBILITY, d);
        g._setCallback(google.idlglue.NodeObserver.GET_RECT_IN_PIXELS, c);
        b.ma = new google.idlglue.TagObserver("iframe", document.body, g)
    };
    google.earth.IframeShimSimulator.prototype.Z = 
    function(a) {
        var b = google.idlglue;
        try {
            this.a.getWindowWidth_()
        } catch (f) {
            return new b.Rect(0, 0, 0, 0)
        }
        var c = b.getElementRect(this.Wa), d = b.getElementRect(a), g = d.left - c.left, e = d.top - c.top, i = this.l(), l = i;
        if (b.getBrowser() == b.BROWSER_SAFARI) {
            l = 1
        }
        return new b.Rect(Math.round(g * l), Math.round(e * l), Math.round(d.width * i), Math.round(d.height * i))
    };
    google.earth.IframeShimSimulator.prototype.l = function() {
        var a = this, b = a.Wa.clientWidth;
        if (b > 0 && a.a.getWindowWidth_() > 0) {
            return a.a.getWindowWidth_() / b
        } else {
            return 1
        }
    };
    google.earth.IframeShimSimulator.prototype.Fa = function() {
        var a = this;
        if (a.ma) {
            a.ma.destroy();
            a.ma = null
        }
    };
    google.earth.InProcessBalloonManager = function(a) {
        var b = this;
        b.a = a.iface;
        b.rb = false;
        google.idlglue.addEventListener(b.a, "balloonchangenotify_", function() {
            b.g("EVENT: balloonchangenotify");
            var f = b.a.getBalloon();
            if (f) {
                b.Ga(f)
            } else {
                b.a.closeBalloon_()
            }
        }, false)
    };
    google.earth.InProcessBalloonManager.prototype.Ga = function(a) {
        var b = this, f = a.getType();
        if (f == "GEFeatureBalloon") {
            b.a.showFeatureBalloon_(a.getFeature(), 1, 1, true, true)
        } else if (f == "GEHtmlStringBalloon") {
            var c = a.getContentString()
        } else if (f == "GEHtmlDivBalloon") {
            throw "GEHtmlDivBalloon is not supported in inprocess plugin";
        }
    };
    google.earth.InProcessBalloonManager.prototype.g = function(a) {
        var b = this;
        if (b.rb) {
            window.console.log("[inprocess_balloon log] " + a)
        }
    };
    google.earth.TermsOfUseManager = function(a, b, f) {
        var c = this;
        c.a = a.iface;
        c.cb = function() {
            c.db()
        };
        c.pb = function() {
            c.oa()
        };
        c.sb = function() {
            c.fb()
        };
        c.tb = function() {
            c.gb()
        };
        google.idlglue.addEventListener(c.a, "termsofusemoved_", c.cb, false);
        google.idlglue.addEventListener(c.a.getView(), "viewchangebegin", c.sb, false);
        google.idlglue.addEventListener(c.a.getView(), "viewchangeend", c.tb, false);
        c.L = null;
        c.j = b;
        c.k = c.j.ownerDocument;
        c.b = null;
        c.qb = 250;
        c.fa = "";
        c.na = "";
        c.ha = "";
        c.R = "";
        c.qa = 0;
        c.ra = 0;
        c.N = 0;
        c.O = 0;
        c.d = null;
        google.idlglue.addErrorCleanupCallback(a, function() {
            c.p()
        });
        c.b = c.k.createElement("div");
        c.b.style.cssText = "z-index: 100; position: absolute; visibility: hidden;";
        c.b.style.visibility = "hidden";
        c.j.appendChild(c.b);
        c.q = c.k.createElement("div");
        c.q.style.cssText = "margin: 0px; padding: 0px 2px; overflow: hidden; text-align: center; font-size: 11px; font-family: sans-serif; ";
        c.b.appendChild(c.q);
        c.t = document.createElement("a");
        c.t.style.color = "#6677ce";
        c.t.setAttribute("target", "_new");
        c.t.setAttribute("href", 
        f);
        c.t.innerHTML = c.a.getTermsOfUseLinkText_();
        c.q.appendChild(c.t);
        c.d = c.k.createElement("iframe");
        c.d.name = "iframeshim";
        c.d.style.position = "absolute";
        c.d.style.left = "0px";
        c.d.style.top = "0px";
        c.d.style.width = "100%";
        c.d.style.height = "100%";
        c.d.style.filter = "progid:DXImageTransform.Microsoft.Alpha(opacity=0)";
        c.d.style.zIndex = -10000;
        c.d.setAttribute("frameborder", "0");
        c.d.setAttribute("scrolling", "no");
        c.d.setAttribute("src", "javascript:void(0);");
        c.b.appendChild(c.d);
        window.setTimeout(c.cb, 0)
    };
    google.earth.TermsOfUseManager.prototype.ja = 
    function() {
        var a = this;
        a.b.style.visibility = "";
        a.b.style.left = a.fa;
        a.b.style.top = a.na;
        a.b.style.right = a.ha;
        a.b.style.bottom = a.R
    };
    google.earth.TermsOfUseManager.prototype.Pa = function() {
        var a = this;
        a.b.style.visibility = "hidden";
        a.b.style.left = -window.screen.width + "px";
        a.b.style.top = -window.screen.height + "px";
        a.b.style.right = "";
        a.b.style.bottom = ""
    };
    google.earth.TermsOfUseManager.prototype.db = function() {
        var a = this, b = a.q.scrollWidth, f = a.q.scrollHeight, c = a.a.getTermsOfUseX_(), d = a.a.getTermsOfUseY_() + a.a.getTermsOfUseYOffset_();
        if (c >= 0) {
            a.fa = c + "px";
            a.ha = "";
            a.qa = c;
            a.N = c + b
        } else {
            a.fa = "";
            a.ha = -c + "px";
            a.N = a.j.scrollWidth + c;
            a.qa = a.N - b
        }
        if (d >= 0) {
            a.na = "";
            a.R = d + "px";
            a.ra = d;
            a.O = d + f
        } else {
            a.na = -d + "px";
            a.R = "";
            a.O = a.j.scrollHeight + d;
            a.ra = a.O - f
        }
        a.oa();
        a.ja()
    };
    google.earth.TermsOfUseManager.prototype.C = function() {
        var a = this;
        if (a.L != null) {
            window.clearTimeout(a.L);
            a.L = null
        }
    };
    google.earth.TermsOfUseManager.prototype.fb = function() {
        var a = this;
        a.C();
        a.Pa()
    };
    google.earth.TermsOfUseManager.prototype.gb = function() {
        var a = this;
        a.C();
        a.L = window.setTimeout(a.pb, 
        a.qb)
    };
    google.earth.TermsOfUseManager.prototype.p = function() {
        var a = this;
        a.C();
        a.b.style.display = "none";
        try {
            a.j.removeChild(a.b)
        } catch (b) {
        }
        a.b = null
    };
    google.earth.TermsOfUseManager.prototype.M = function(a) {
        var b = "";
        for (; ; ) {
            var f = a % 16;
            b = "0123456789ABCDEF".substring(f, f + 1) + b;
            a = Math.floor(a / 16);
            if (a <= 0 && b.length >= 2) {
                break
            }
        }
        return b
    };
    google.earth.TermsOfUseManager.prototype.oa = function() {
        var a = this, b = a.a.getAverageCaptureColor_(a.qa, a.ra, a.N, a.O), f = b >> 16 & 255, c = b >> 8 & 255, d = b & 255, g = "#6677ce", e = Math.abs(d - 102) * 
        0.3 + Math.abs(c - 119) * 0.59 + Math.abs(f - 206) * 0.11;
        if (e < 40) {
            g = "#111648"
        }
        var i = "#" + a.M(d) + a.M(c) + a.M(f);
        a.b.style.backgroundColor = i;
        a.q.style.backgroundColor = i;
        a.t.style.color = g;
        a.ja()
    };
    var _pluginInitCode = function(a, b, f, c) {
        var d = a.iface, g = window.google;
        if (d && d.isInProcess_()) {
            g.earth.addEventListener = g.idlglue.addEventListener;
            g.earth.removeEventListener = g.idlglue.removeEventListener;
            g.idlglue.init(a);
            a.balloonManager = new g.earth.InProcessBalloonManager(a);
            b(d);
            return
        }
        var e = {};
        if (c && typeof c == "object") {
            e.optArgs = c
        } else {
            e.optArgs = {}
        }
        var i = function(h, j, o) {
            if (!h in e.optArgs || typeof e.optArgs[h] != j) {
                e.optArgs[h] = o
            }
        }, l = function(h, j, o) {
            var n = true;
            if (e.optArgs[h] == null || typeof e.optArgs[h] != 
            "object" || e.optArgs[h].length != j.length) {
                n = false
            }
            var s = e.optArgs[h];
            for (var t = 0; t < j.length && n == true; ++t) {
                if (typeof s[t] != j[t]) {
                    n = false
                }
            }
            if (n == false)
                e.optArgs[h] = o
        }, m = function(h) {
            if (h && typeof h == "object" && "oauthToken" in h && "oauthSecret" in h && "oauthScope" in h && typeof h.oauthToken == "string" && typeof h.oauthSecret == "string" && typeof h.oauthScope == "string") {
                return true
            }
            return false
        }, p = function(h) {
            if (h && typeof h == "object" && "oauthToken" in h && "signingUrl" in h && typeof h.oauthToken == "string" && typeof h.signingUrl == 
            "string") {
                return true
            }
            return false
        };
        a.pluginDiv.logStore = {};
        i("database", "string", "");
        i("username", "string", "");
        i("password", "string", "");
        i("timeout", "number", 60);
        i("visibility", "boolean", false);
        l("lookAt", ["number", "number", "number", "string", "number", "number", "number"], null);
        l("camera", ["number", "number", "number", "string", "number", "number", "number"], null);
        i("language", "string", "");
        i("fatalErrorCallback", "function", null);
        i("oauthInfo", "object", null);
        if (!m(e.optArgs.oauthInfo))
            e.optArgs.oauthInfo = 
            null;
        i("oauth2Info", "object", null);
        if (!p(e.optArgs.oauth2Info))
            e.optArgs.oauth2Info = null;
        i("isSecure", "boolean", false);
        i("setCookies", "boolean", false);
        i("allowEmptyClientId", "boolean", false);
        var k = g.earth.ErrorCode;
        e.initCallback = b;
        e.failureCallback = f;
        e.timeElapsed = 0;
        e.secondsToWait = e.optArgs.timeout || 60;
        e.heartbeatInterval = 1000;
        e.earthConnected = false;
        e.earthReady = k.ERR_PLUGIN_NOT_READY;
        e.initError = "";
        e.initErrorDetail = "";
        e.allowUsageLogging = true;
        if ("allowUsageLogging" in g.earth)
            e.allowUsageLogging = 
            g.earth.allowUsageLogging;
        var q = "";
        if (e.optArgs.language) {
            q = "intl/" + e.optArgs.language + "/"
        }
        e.TERMS_OF_USE_URL = "www.google.com/" + q + "help/terms_maps.html";
        if (e.optArgs.isSecure)
            e.TERMS_OF_USE_URL = "https://" + e.TERMS_OF_USE_URL;
        else
            e.TERMS_OF_USE_URL = "http://" + e.TERMS_OF_USE_URL;
        e.doInitializationFailure = function(h, j) {
            e.doFailure(h, j, null);
            if (e.failureCallback) {
                e.failureCallback(h)
            }
        };
        var r = document.location.hash;
        if (a.browser == "ie" || r.indexOf("nopairing") > -1) {
            a.iface.setNoPairing_();
            a.eventNodeId = a.pluginId
        } else {
            a.scriptingEmbedId = 
            "scriptembed_" + a.pluginId;
            a.eventNodeId = a.scriptingEmbedId;
            var u = document.createElement("div");
            u.style.position = "absolute";
            u.style.left = -screen.width * 2 + "px";
            u.style.top = -screen.width * 2 + "px";
            u.style.width = "1px";
            u.style.height = "1px";
            a.scriptingDiv = u;
            document.body.appendChild(a.scriptingDiv);
            if (!g.idlglue.createPluginAsInnerHTML(a.browser, a.scriptingDiv, a.scriptingEmbedId)) {
                e.doInitializationFailure(k.ERR_INIT, "failed to create display embed");
                return
            }
            a.scriptingEmbed = a.scriptingDiv.firstChild;
            a.displayEmbed = 
            a.iface;
            a.iface = a.scriptingEmbed;
            a.displayEmbed.setPairId_(a.iface.newPairId_());
            g.idlglue.addErrorCleanupCallback(a, function() {
                document.body.removeChild(a.scriptingDiv);
                a.scriptingDiv = null;
                a.scriptingEmbed = null;
                a.displayEmbed = null
            })
        }
        e.unload = function() {
            if (window.removeEventListener) {
                window.removeEventListener("unload", e.unload, false)
            } else if (window.detachEvent) {
                window.detachEvent("onunload", e.unload)
            }
            if (a.balloonManager)
                a.balloonManager.p();
            g.idlglue.notifyInitCodeUnloaded()
        };
        if (window.addEventListener) {
            window.addEventListener("unload", 
            e.unload, false)
        } else if (window.attachEvent) {
            window.attachEvent("onunload", e.unload)
        }
        e.pluginVersion = 0;
        e.earthVersion = 0;
        try {
            e.pluginVersion = a.iface.getPluginVersion()
        } catch (z) {
            e.doInitializationFailure(k.ERR_INIT, z.toString())
        }
        e.initOnBridgeReady = function(h) {
            var j = a.iface;
            try {
                h.earthVersion = j.getEarthVersion();
                if (h.earthVersion != h.pluginVersion) {
                    h.doInitializationFailure(k.ERR_VERSION, "earthversion:" + h.earthVersion);
                    return false
                }
                if (h.optArgs.oauthInfo) {
                    j.setOauthInfo_(h.optArgs.oauthInfo.oauthToken, 
                    h.optArgs.oauthInfo.oauthSecret, h.optArgs.oauthInfo.oauthScope)
                } else if (h.optArgs.oauth2Info) {
                    j.setOauth2TokenForUrl(h.optArgs.oauth2Info.oauthToken, h.optArgs.oauth2Info.signingUrl)
                } else if (h.optArgs.setCookies) {
                    j.setCookiesForCurrentSite_()
                }
                j.setMainDatabase_(h.optArgs.database, h.optArgs.username, h.optArgs.password)
            } catch (o) {
                h.doInitializationFailure(k.ERR_INIT, o.toString());
                return false
            }
            return true
        };
        e.hideLoadingMessage = function() {
            var h = a.iface;
            a.messageDiv.style.display = "none";
            h.getWindow().resize_(a.topDiv.clientWidth, 
            a.topDiv.clientHeight);
            a.pluginDiv.style.left = "0px";
            a.pluginDiv.style.top = "0px"
        };
        e.initEarthView = function(h) {
            var j = a.iface;
            j.getOptions().setMapType(j.MAP_TYPE_EARTH);
            j.getOptions().setFlyToSpeed(j.SPEED_TELEPORT);
            var o = null;
            if (e.optArgs.lookAt != null) {
                o = j.createLookAt("");
                o.set(e.optArgs.lookAt[0], e.optArgs.lookAt[1], e.optArgs.lookAt[2], j[e.optArgs.lookAt[3]], e.optArgs.lookAt[4], e.optArgs.lookAt[5], e.optArgs.lookAt[6])
            } else if (e.optArgs.camera != null) {
                o = j.createCamera("");
                o.set(e.optArgs.camera[0], 
                e.optArgs.camera[1], e.optArgs.camera[2], j[e.optArgs.camera[3]], e.optArgs.camera[4], e.optArgs.camera[5], e.optArgs.camera[6])
            } else {
                o = j.createLookAt("");
                o.set(25, -40, 25484040, j.ALTITUDE_RELATIVE_TO_GROUND, 0, 0, 0)
            }
            j.getView().setAbstractView(o);
            j.getOptions().setFlyToSpeed(1)
        };
        e.initOnEarthFullyInitialized = function(h) {
            var j = a.iface;
            try {
                j.resetCutouts_();
                a.iframeShimSimulator = new g.earth.IframeShimSimulator(a);
                a.balloonManager = new g.earth.BalloonManager2(a, a.pluginDiv, e.optArgs.language);
                a.balloonManager.init();
                a.termsOfUseManager = new g.earth.TermsOfUseManager(a, a.pluginDiv, e.TERMS_OF_USE_URL)
            } catch (o) {
                e.initError = k.ERR_INIT;
                e.initErrorString = o.toString();
                return false
            }
            e.hideLoadingMessage();
            window.setTimeout(function() {
                h.heartbeat(h)
            }, h.heartbeatInterval);
            if ((g.idlglue.logCsi || g.idlglue.logCsi2) && a.startLoadingTime && e.allowUsageLogging) {
                var n = a.pluginDiv.logStore;
                n.prt = (new Date).getTime() - a.startLoadingTime;
                var s = j.getNewEarthInstanceCreated_() ? "e=createge" : "e=attachge";
                n.cp_precreate = j.getLogValue_(0);
                n.cp_postcreate = j.getLogValue_(1);
                var t = [["ci_prestart", n.ci_prestart], ["ci_start", n.ci_start], ["ci_poststart", n.ci_poststart], ["cp_precreate", n.cp_precreate], ["cp_postcreate", n.cp_postcreate], ["prt", n.prt], ["serialTime", j.getLogValue_(2)]];
                if (n.prewarmTime >= 0) {
                    s += ",prewarmed";
                    t.push(["prewarmTime", n.prewarmTime]);
                    if (n.prewarmFinished == 1)
                        s += ",prewarmedFinished"
                } else if (n.didPrewarm) {
                    s += ",prewarmed"
                }
                if (g.idlglue.logCsi2) {
                    g.idlglue.logCsi2("earth_plugin", h.pluginVersion, e.optArgs.isSecure, t, s)
                } else {
                    g.idlglue.logCsi("earth_plugin", 
                    h.pluginVersion, t, s)
                }
            }
            if (h.initCallback) {
                h.initCallback(j)
            }
            return true
        };
        e.loadPoll = function(h) {
            var j = 100, o = false, n = a.iface;
            h.timeElapsed += j;
            if (h.timeElapsed > h.secondsToWait * 1000) {
                o = true
            }
            if (!h.earthConnected) {
                try {
                    h.earthConnected = n.testRpcReady_(o)
                } catch (s) {
                    o = true;
                    try {
                        e.initError = g.earth.ErrorCodeToString[n.getBridgeErrorCode_()];
                        e.initErrorDetail = n.getBridgeErrorDetail_()
                    } catch (t) {
                        e.initError = k.ERR_INIT
                    }
                }
                if (h.earthConnected) {
                    if (!h.initOnBridgeReady(h)) {
                        return
                    }
                }
            }
            if (h.earthConnected && h.earthReady != 
            k.ERR_OK && !e.initError) {
                try {
                    h.earthReady = g.earth.ErrorCodeToString[n.testEarthFullyInitialized_()];
                    if (h.earthReady == k.ERR_DATABASE_LOGIN_FAILURE) {
                        e.initError = h.earthReady
                    }
                } catch (s) {
                    e.initError = k.ERR_INIT
                }
                if (h.earthReady == k.ERR_OK) {
                    if (h.initOnEarthFullyInitialized(h))
                        return
                }
            }
            if (!o && !e.initError)
                window.setTimeout(function() {
                    h.loadPoll(h)
                }, j);
            else
                h.doInitializationFailure(e.initError, e.initErrorDetail)
        };
        e.initEarthViewFromRenderReadyCB = function() {
            try {
                e.initEarthView(e);
                if (e.optArgs.visibility == true) {
                    e.hideLoadingMessage();
                    a.iface.getWindow().setVisibility(true)
                }
            } catch (h) {
                e.initError = k.ERR_INIT;
                e.initErrorString = h.toString();
                return
            }
        };
        e.earthReadyEvent = function() {
        };
        e.doFailure = function(h, j, o) {
            e.doHeartbeat = false;
            if (!j) {
                j = ""
            }
            j += ",pluginversion:" + e.pluginVersion;
            if (o) {
                o(h, j)
            }
            g.idlglue.showError(a, h, j)
        };
        e.heartbeat = function(h) {
            var j = a.iface;
            if (!e.doHeartbeat) {
                return
            }
            var o = false;
            try {
                o = j.noOp_()
            } catch (n) {
            }
            if (!o) {
                var s = k.ERR_BRIDGE, t = "heartbeat timeout";
                try {
                    var y = g.earth.ErrorCodeToString[j.getBridgeErrorCode_()];
                    if (y != k.ERR_OK) {
                        s = 
                        y;
                        t = j.getBridgeErrorDetail_()
                    }
                } catch (n) {
                }
                h.doFailure(s, t, e.optArgs.fatalErrorCallback);
                return
            }
            if (a.displayEmbed && j.isDetached_()) {
                if ("getSelf" in a.displayEmbed) {
                    a.displayEmbed.setPairId_(j.newPairId_());
                    j.restorePairing_()
                }
            }
            var v = a.pluginDiv;
            while (v && v != document.body) {
                v = v.parentNode
            }
            if (!v) {
                h.doFailure(k.ERR_DESTROYED, "", e.optArgs.fatalErrorCallback);
                return
            }
            window.setTimeout(function() {
                h.heartbeat(h)
            }, h.heartbeatInterval)
        };
        if (window.location.protocol != "file:") {
            try {
                var A = g.loader.KeyVerified, w = g.loader.ApiKey, 
                B = g.loader.LoadFailure;
                if (B || !A || typeof w != "string" || w == "notsupplied" || w.length < 20) {
                    var C = new g.earth.ClientIdCheck(function() {
                        if (e.earthReady == k.ERR_OK) {
                            a.iface.kill_();
                            e.doInitializationFailure(k.ERR_API_KEY, "")
                        } else {
                            e.initError = k.ERR_API_KEY;
                            e.initErrorDetail = "validation error"
                        }
                    }, 0, e.optArgs.isSecure, e.optArgs.allowEmptyClientId);
                    C.ua()
                }
            } catch (I) {
                e.doInitializationFailure(k.ERR_API_KEY, "noloader");
                return
            }
        }
        e.lastShowTermsOfUseTime = -1;
        e.showTermsOfUse = function() {
            var h = (new Date).getTime();
            if (e.lastShowTermsOfUseTime == 
            -1 || h - e.lastShowTermsOfUseTime > 2000) {
                var j = window.open(e.TERMS_OF_USE_URL, "google_maps_terms_of_use", "resizable=yes,scrollbars=yes,menubar=yes,location=yes,toolbar=yes,status=yes");
                if (j == null) {
                    window.location.href = e.TERMS_OF_USE_URL
                }
                e.lastShowTermsOfUseTime = h
            }
        };
        e.doHeartbeat = true;
        g.earth.addEventListener = g.idlglue.addEventListener;
        g.earth.removeEventListener = g.idlglue.removeEventListener;
        var D = 5, E = 0, x = function() {
            a.pluginDiv.logStore.ci_prestart = (new Date).getTime() - a.startLoadingTime;
            var h = (new Date).getTime(), 
            j = a.iface.start_(e.optArgs.database, e.optArgs.language), o = (new Date).getTime();
            a.pluginDiv.logStore.ci_start = o - h;
            var n = g.earth.ErrorCodeToString[j];
            if (n == k.ERR_PLUGIN_NOT_READY) {
                if (E++ < D) {
                    window.setTimeout(x, 100)
                } else {
                    e.doInitializationFailure(k.ERR_INIT, "start_() timed out")
                }
            } else if (n == k.ERR_OK) {
                if (g.idlglue.init(a)) {
                    window.google.earth.addEventListener(a.iface, "renderready_", function() {
                        e.initEarthViewFromRenderReadyCB()
                    });
                    e.loadPoll(e)
                } else {
                    e.doInitializationFailure(k.ERR_INIT, "idlglue.init() failed")
                }
            } else if (n == 
            k.ERR_BAD_URL) {
                e.doInitializationFailure(k.ERR_BAD_URL, "Illegal character in database URL")
            } else if (n == k.ERR_INVALID_LANGUAGE) {
                e.doInitializationFailure(k.ERR_INVALID_LANGUAGE, "Invalid character in language code")
            } else {
                e.doInitializationFailure(k.ERR_INIT, "Plugin returned an error on init.")
            }
            a.pluginDiv.logStore.ci_poststart = (new Date).getTime() - o
        };
        x()
    };
    ;
    return _pluginInitCode;
})()
