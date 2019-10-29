from flask import Flask
from flask import escape
from flask import render_template
from flask import request
from flask import redirect
from flask import url_for
from flask import abort
import werkzeug
from werkzeug.utils import secure_filename
from flask import make_response
from flask import session
from flask import flash, get_flashed_messages
import logging.config
from flask import send_file
import io
from flask import send_from_directory

#logging.config.fileConfig('logging.conf')

app = Flask(__name__)

@app.route('/')
def hello():
	return 'Hello World!'

@app.route('/rt_variable/')
@app.route('/rt_variable/<var>')
@app.route('/rt_variable_i/<int:var>')
@app.route('/rt_variable_f/<float:var>')
@app.route('/rt_variable_p/<path:var>')
@app.route('/rt_variable_u/<uuid:var>')
@app.route('/rt_variable_a/<any(s1,s2,s3):var>')
def fn_rt_variable(var=None):
	return f'var = {var}, type(var) = {escape(type(var))}'

@app.route('/rt_variable_m/end')
@app.route('/rt_variable_m/<s1>/end')
@app.route('/rt_variable_m/<s1>/<s2>/end')
def fn_rt_variable_m(s1=None, s2='default'):
	return f's1 = {s1}, s2 = {s2}'

@app.route('/ex_template')
@app.route('/ex_template/<t1>')
def fn_template(t1=None):
	return render_template('template_example.html', var=t1)
	
@app.route('/ex_req', methods=['GET', 'POST'])
def fn_req():
	print(request.method)
	print(request.path)
	print(request.content_length)
	print(request.mimetype)

	print(request.args.get('u1'))
	print(request.args['u2'])
	print(request.args.getlist('u1'))

	print(request.form.get('f1'))
	print(request.form['f2'])
	print(request.form.getlist('f2'))

	print(request.headers.get('Connection'))
	print(request.headers['Connection'])
	print(request.headers.getlist('Connection'))
	
	return 'call fn_req().'

@app.route('/ex_redirect')
def fn_redirect():
	return redirect(url_for('fn_rt_variable'), code = 301)

@app.route('/ex_abort/<int:var>')
def fn_abort(var):
	abort(var)

#@app.errorhandler(400)
#@app.errorhandler(werkzeug.exceptions.HTTPException)
@app.errorhandler(ZeroDivisionError)
def fn_error_handler(error):
	print(error)
	return 'call fn_error_handler().'

@app.route('/ex_zderr')
def fn_zderr():
	i = 1 / 0
	return 'call fn_zderr().'

@app.route('/ex_upload', methods=['GET', 'POST'])
def fn_upload():
	if request.method == 'POST' and 'file' in request.files:
		f = request.files['file']
		f.save('upload_files/' + secure_filename(f.filename))
		return 'file uploaded.'
		
	return '''
	<!doctype html>
	<title>Upload</title>
	<form method="post" enctype="multipart/form-data">
	  <input type="file" name="file">
	  <input type="submit" value="Upload">
	</form>
	'''

@app.route('/ex_res/<int:var>')
def fn_res(var):
	resp = make_response('call fn_res().', var)
	resp.headers['ex_res'] = 'OK!!'
	return resp
	
@app.route('/ex_cookie')
@app.route('/ex_cookie/<var>')
def fn_cookie(var=None):
	if var is None:
		ck = request.cookies.get('ck')
		return f'ck = {ck}'
	else:
		resp = make_response('set cookie.')
		resp.set_cookie('ck', var)
		return resp
	
app.secret_key = 'test'

@app.route('/ex_session')
@app.route('/ex_session/<var>')
def fn_session(var=None):
	if var is None:
		sess = session.get('sess')
		return f'sess = {sess}'
	else:
		session['sess'] = var
		return 'set session.'
	
@app.route('/ex_flash')
@app.route('/ex_flash/<var>')
def fn_flash(var=None):
	if var is None:
		fl = get_flashed_messages()
#		fl = get_flashed_messages(with_categories=True, category_filter=['debug', 'info'])
		return f'fl = {fl}'
	else:
		flash(var)
#		flash('DEBUG:' + var, 'debug')
#		flash('INFO:' + var, 'info')
#		flash('ERROR:' + var, 'error')
		return 'set flash.'

@app.route('/ex_logging')
@app.route('/ex_logging/<var>')
def fn_logging(var=None):
	app.logger.info(var)
	app.logger.warning(var)
	app.logger.error(var)
	return 'call fn_logging().'

@app.route('/ex_send_file/<path:var>')
def fn_send_file(var):
	return send_file(var, as_attachment=True)

@app.route('/ex_send_file_obj/<var>')
def fn_send_file_obj(var):
	fp = io.BytesIO(var.encode())
	return send_file(fp, attachment_filename='test.txt', as_attachment=True)

@app.route('/ex_send_from_dir/<path:var>')
def fn_send_from_dir(var):
	return send_from_directory('C:/flask_work/', var, as_attachment=True)

