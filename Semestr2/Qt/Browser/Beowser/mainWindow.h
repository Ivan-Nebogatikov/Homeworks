#pragma once
#include <QMainWindow>
#include <QtWebKit>
#include <QtNetwork>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private slots:
    void loadPage(QUrl url);
    void on_goButton_clicked();
    void enterPressed();
    void on_refreshButton_clicked();

private:
    Ui::MainWindow *ui;
    void textToUrl();
};
