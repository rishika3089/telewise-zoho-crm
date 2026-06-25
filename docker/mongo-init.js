db = db.getSiblingDB('telewise_crm');

db.createCollection('oauth_tokens');
db.createCollection('crm_events');
db.createCollection('notification_logs');

print('telewise_crm database initialized.');