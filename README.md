# CKDataViewer
Contains a suite of tools for dataviewing and PID tuning.

---

### CKPIDTuner
A PID Tuner that allows realtime tuning using the TunablePIDOSC library

---

### CKDataViewer
A simple application to graphically view the live datastream from our Robot.

### Protocol Specifics
This application will graph any data sent to it using the following OSC Packet Format:

```
Address: /LogData
<Key>:<Value>;
```

This packet can contain any number of strings.
