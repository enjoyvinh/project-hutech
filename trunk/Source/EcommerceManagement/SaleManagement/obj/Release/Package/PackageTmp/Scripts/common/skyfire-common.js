/**
 * Copyright(c)  2014 SystemEXE,Inc.  All Rights Reserved.
 */
/**
 *
 * @author huy-du
 */

/**
 * 定数を管理するオブジェクト。
 */
var Constants = {};

Constants = {

    /**
     * 定数をSessionStorageにfor function。
     */
    setConstant : function(value) {

        sessionStorage.setItem('constants', JSON.stringify(value));
    },

    /**
     * 指定されたキーの定数をSessionStorageから取得する。
     *
     * @return 指定されたキーの定数
     */
    getConstant : function(key) {

        return JSON.parse(sessionStorage.getItem('constants'))[key];
    }
};

/**
 * メッセージを管理するオブジェクト。
 */
var Messages = {};

Messages = {

    /**
     * メッセージをSessionStorageにfor function。
     */
    setMessage : function(data) {
        sessionStorage.setItem('messageWrapper', JSON.stringify(data));
    },

    /**
     * 指定されたキーのメッセージをSessionStorageから取得する。
     *
     * @return 指定されたキーのメッセージ
     */
    getMessage : function(key, params) {
        //console.log(sessionStorage);
        var message = JSON.parse(sessionStorage.getItem('messageWrapper'))[key];

        if (!params) {
            return message;
        }

        var _params = params.split(',');

        for (var i = 0; i < _params.length; i++) {
            var _param = this.getMessage(_params[i]);
            message = message.replace(/\{[0-9]+\}/, _param ? _param : _params[i]);
        }

        return message;
    }
};

/**
 * Date Utils
 */
var DateUtils = {};

DateUtils = {
    getFirstDateOfMonth : function(){
        var today = new Date();
        return new Date( today.getFullYear().toString(), today.getMonth().toString(),"01");
    },

    getLateDateOfMonth : function(){
        var today = new Date();
        return new Date( today.getFullYear().toString(), (today.getMonth() + 1 ).toString(),0);
    }
};

/**
 * クライアント側で共通で実施するバリデート処理を定義したオブジェクト。
 */
var ValidateUtil = {};

ValidateUtil =
        {
            /**
             * 当該オブジェクトのメソッドが使用するプライベート関数です。指定された正規表現にマッチしているか確認します。
             */
            _isValidated : function(value, matcher) {

                return matcher.test(value.rtrim());
            },

            /**
             * 必須入力をチェックします。
             *
             * @param {string}
             *            value 入力値
             * @return {boolean} true:成功, false:失敗
             */
            isValidTextRequired : function(value) {

                if (value != null) {
                    return value ? this.isValidTextLength(value, 1, Infinity) : value;
                } else {
                    return false;
                }
            },

            /**
             * 禁則文字が含まれていないことをチェックします。
             *
             * @param {string}
             *            value 入力値
             * @return {boolean} true:成功, false:失敗
             */
            isValidTextInvalidChars : function(value) {

                if (value == null || value == '') {
                    return true;
                }

                var reg = new RegExp('[' + Configulation.INVALID_CHARS + ']');
                if (true == this._isValidated(value, reg)) {
                    return false;
                }

                return true;
            },

            /**
             * 文字列の桁数をチェックします。
             *
             * @param {string}
             *            value 入力値
             * @param {number}
             *            lower 最小桁数
             * @parma {number} upper 最大桁数
             * @return {boolean} true:成功, false:失敗
             */
            isValidTextLength : function(value, lower, upper) {

                if (value == null || value == '') {
                    return true;
                }

                if (value != null) {
                    var _value = value.rtrim();
                    if (upper == undefined) {
                        upper = lower;
                    }
                    return _value.length >= lower && _value.length <= upper;
                } else {
                    return false;
                }
            },

            /**
             * 文字列の半角数字をチェックします。
             *
             * @param {string}
             *            value 入力値
             * @return {boolean} true:成功, false:失敗
             */
            isValidTextNumeric : function(value) {

                if (value == null || value == '') {
                    return true;
                }

                return this._isValidated(value, /^[\d]*$/);
            },

            /**
             * 文字列の数値をチェックします。
             *
             * @param {string}
             *            value 入力値
             * @return {boolean} true:成功, false:失敗
             */
            isValidTextNumber : function(value) {

                if (value == null || value == '') {
                    return true;
                }

                return this._isValidated(value, /^[\d-\u002E]*$/) && isFinite(value);
            },

            /**
             * 文字列の半角英字をチェックします。
             *
             * @param {string}
             *            value 入力値
             * @return {boolean} true:成功, false:失敗
             */
            isValidTextAlpha : function(value) {

                if (value == null || value == '') {
                    return true;
                }

                return this._isValidated(value, /^[A-Za-z]*$/);
            },

            /**
             * 文字列の半角英数字をチェックします。
             *
             * @param {string}
             *            value 入力値
             * @return {boolean} true:成功, false:失敗
             */
            isValidTextAlphaNumeric : function(value) {

                if (value == null || value == '') {
                    return true;
                }

                return this._isValidated(value, /^[A-Za-z\d]*$/);
            },
            /**
             * 文字列のメールをチェックします。
             *
             * @param {string}
             *            value 入力値
             * @return {boolean} true:成功, false:失敗
             */
            isValidTextEmail : function(value) {

                if (value == null || value == '') {
                    return true;
                }

                return this._isValidated(value, /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/);
            },
            /**
             * 文字列の半角英字数字(記号含む)をチェックします。
             *
             * @param {string}
             *            value 入力値
             * @return {boolean} true:成功, false:失敗
             */
            isValidTextHalf : function(value) {

                if (value == null || value == '') {
                    return true;
                }

                var reg = new RegExp('^[A-Za-z\d' + Configulation.VALID_CHARS_HALF + ']*$');
                return this._isValidated(value, reg);
            },

            /**
             * 文字列の日付形式をチェックします。
             *
             * @param {string}
             *            value 入力値
             * @return {boolean} true:成功, false:失敗
             */
            isValidTextDate : function(value) {

                if (value == null || value == '') {
                    return true;
                }

                if (this._isValidated(value, /^[1|2]\d{3}\-\d{2}\-\d{2}$/)) {
                    var date = new Date(value);
                    value = value.split('-');
                    return date.getFullYear() === +value[0] && date.getMonth() + 1 === +value[1]
                            && date.getDate() === +value[2];
                }
                return false;
            },

            /**
             * 文字列の電話番号形式をチェックします。
             *
             * @param {string}
             *            value 入力値
             * @return {boolean} true:成功, false:失敗
             */
            isValidTextTelNo : function(value) {

                if (value == null || value == '') {
                    return true;
                }

                if (false == this._isValidated(value, /^[0-9-]*$/)) {
                    return false;
                }

                if (true == this._isValidated(value, /^-.*/)) {
                    return false;
                }

                if (true == this._isValidated(value, /.*-$/)) {
                    return false;
                }

                return true;
            },

            /**
             * 文字列のバイト数(UTF-8)をチェックします。
             *
             * @param {string}
             *            value 入力値
             * @param {number}
             *            size 最大サイズ(Byte)
             * @return {boolean} true:成功, false:失敗
             */
            isValidBytesLength : function(value, size) {

                if (value == null || value == '') {
                    return true;
                }

                if ((new Blob([ value ], {
                    type : 'text/plain'
                })).size > size) {
                    return false;
                }

                return true;
            },

            isValidTextEmpty : function(value) {
                if (value == null || value == '' || value == undefined) {
                    return true;
                }
                return false;
            }
        };

/**
 * 入力チェックで利用する入力許可文字／禁則文字の定義オブジェクトです。
 */
var Configulation = {
    VALID_CHARS_HALF : '!#$%()+-./={}',
    INVALID_CHARS : '￥＄￠￡Å‰＃＆＊＠§☆★○●◎◇◆□■△▲▽▼※〒→←↑↓〓♯♭♪†‡¶◯´｀¨♂♀─│┌┐┘└├┬┤┴┼━┃┏┓┛┗┣┳┫┻╋┠┯┨┷┿┝┰┥┸╂'
};

/**
 * BSA(対表面積)の計算を行うユーティリティオブジェクトです。
 */
var BsaCalcUtil = {};

BsaCalcUtil = {

    /**
     * BSAをDuBois式で計算し、結果を返却します。
     *
     * @param {string}
     *            height 身長
     * @param {string}
     *            weight 体重
     * @return {string} DuBois BSA
     */
    calcBsaDuBois : function(height, weight) {

        // 身長体重が未指定の場合は空文字を返却
        if (height == null || height == '' || weight == null || weight == '') {
            return '';
        }

        // 身長体重が数値でない場合は空文字を返却
        if (!ValidateUtil.isValidTextNumber(height) || !ValidateUtil.isValidTextNumber(weight)) {
            return '';
        }

        // DuBois式 = 身長 ^ 0.725 * 体重 ^ 0.425 * 0.007184
        var bsa = Math.pow(parseFloat(height), 0.725) * Math.pow(parseFloat(weight), 0.425) * 0.007184;

        // 小数点以下第三位を四捨五入
        return (Math.round(bsa * 100) / 100).toString();
    }
};
